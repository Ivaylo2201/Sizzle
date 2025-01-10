from decimal import Decimal
from django.db import IntegrityError
from django.db.models import QuerySet
from django.core.exceptions import ValidationError as ModelValidationError
from django.shortcuts import get_object_or_404

from rest_framework.authentication import authenticate
from rest_framework.exceptions import AuthenticationFailed, ValidationError
from rest_framework_simplejwt.exceptions import InvalidToken
from .models import Cart, Item, Product
from rest_framework.permissions import IsAuthenticated
from rest_framework_simplejwt.authentication import JWTAuthentication
from .serializers import CartSerializer, ProductSerializer
from rest_framework import generics
from rest_framework.request import Request
from rest_framework.response import Response
from rest_framework_simplejwt.tokens import RefreshToken
from rest_framework_simplejwt.views import TokenObtainPairView, TokenRefreshView

from django.contrib.auth.models import User

class CookieTokenObtainPairView(TokenObtainPairView):
    def post(self, request: Request, *args, **kwargs) -> Response:
        username: str | None = request.data.get('username')
        password: str | None = request.data.get('password')

        if not username or not password:
            return ValidationError({'detail': 'Invalid data'})
        
        user: User | None = authenticate(username=username, password=password)

        if not user:
            return ValidationError({'detail': 'Invalid credentials'})
        
        refresh: RefreshToken = RefreshToken.for_user(user)

        response = Response({'access': str(refresh.access_token)})
        response.set_cookie(key='refresh', value=str(refresh), httponly=True)

        return response

class CookieTokenRefreshView(TokenRefreshView):
    def post(self, request: Request, *args, **kwargs) -> Response:
        request.data['refresh'] = request._request.COOKIES.get('refresh')

        try:
            tokens: dict = super().post(request, *args, **kwargs).data

            response: Response = Response({'access': tokens.get('access')})
            response.set_cookie(key='refresh', value=tokens.get('refresh'), httponly=True)

            return response
        except InvalidToken:
            return AuthenticationFailed({'detail': 'Invalid refresh token'})

class UserCreateAPIView(generics.CreateAPIView):
    def post(self, request: Request, *args, **kwargs) -> Response:
        username: str | None = request.data.get('username')
        password: str | None = request.data.get('password')

        if not username or not password:
            raise ValidationError({'detail': 'Invalid data'})
        
        if User.objects.filter(username=username).exists():
            raise ValidationError({'detail': 'Username already taken!'})
        
        User.objects.create_user(username=username, password=password)

        return Response({'detail': 'Signed up successfully'})
    
class CartRetrieveAPIView(generics.RetrieveAPIView):
    authentication_classes = [JWTAuthentication]
    permission_classes = [IsAuthenticated]

    def get(self, request: Request) -> Response:
        serializer: CartSerializer = CartSerializer(request.user.cart)
        return Response(serializer.data)

class ProductsRetrieveAPIView(generics.RetrieveAPIView):
    def get(self, request: Request) -> Response:
        category: str = request.query_params.get('category')
        products: QuerySet[Product] = Product.objects.all()

        if category:
            products = products.filter(category__name__iexact=category)

        serializer: ProductSerializer = ProductSerializer(products, many=True)
        return Response(serializer.data)
    
class AddToCartCreateAPIView(generics.CreateAPIView):
    authentication_classes = [JWTAuthentication]
    permission_classes = [IsAuthenticated]

    def post(self, request: Request, *args, **kwargs) -> Response:
        pk: int = request.data.get('pk')
        quantity: int = request.data.get('quantity')

        if not pk or not quantity:
            return ValidationError({'detail': 'Invalid data'})
        
        product: Product = get_object_or_404(Product, pk=pk)

        Item.objects.create(product=product, quantity=Decimal(quantity), cart=request.user.cart)

        return Response({'detail': f'{quantity}x {product.name} added to cart'})
    
class RemoveFromCartDestroyAPIView(generics.DestroyAPIView): 
    authentication_classes = [JWTAuthentication]
    permission_classes = [IsAuthenticated]

    def delete(self, request: Request, pk: int) -> Response:
        item: Item = Item.objects.get(pk=pk, cart=request.user.cart)
        item.delete()
        return Response({'detail': f'{item.quantity}x {item.product.name} removed from cart'})