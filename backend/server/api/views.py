from decimal import Decimal
from django.core.exceptions import BadRequest
from django.db.models import QuerySet
from django.shortcuts import get_object_or_404
from test.test_xml_etree import serialize
from .models import Cart, Item, Product
from rest_framework.permissions import IsAuthenticated
from rest_framework_simplejwt.authentication import JWTAuthentication
from .serializers import CartSerializer, ProductSerializer
from rest_framework import generics
from rest_framework.request import Request
from rest_framework.response import Response
from rest_framework_simplejwt.tokens import RefreshToken
from rest_framework_simplejwt.views import TokenObtainPairView

from django.contrib.auth.models import User

class UserCreateAPIView(generics.CreateAPIView):
    def post(self, request: Request, *args, **kwargs) -> Response:
        email: str = request.data.get('email')
        password: str = request.data.get('password')
        
        User.objects.create_user(username=email, password=password)

        return Response({'detail': 'User created'})

class EmailTokenObtainPairView(TokenObtainPairView):
    def post(self, request: Request) -> Response:
        email: str = request.data.get('email')

        user: User | None = User.objects.filter(
            username=email, 
            is_active=True
        ).first()

        if not user:
            return BadRequest({'detail': 'Invalid credentials'})

        refresh_token: RefreshToken = RefreshToken.for_user(user)
        
        return Response({
            'refresh': str(refresh_token), 
            'access': str(refresh_token.access_token)
        })
    
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
            return BadRequest({'detail': 'Invalid data'})
        
        product: Product = get_object_or_404(Product, pk=pk)

        Item.objects.create(product=product, quantity=Decimal(quantity), cart=request.user.cart)

        return Response({'detail': f'{quantity}x {product.name} added to cart'})