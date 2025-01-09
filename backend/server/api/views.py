from django.core.exceptions import BadRequest
from rest_framework.permissions import IsAuthenticated
from rest_framework_simplejwt.authentication import JWTAuthentication
from .serializers import CartSerializer
from rest_framework import generics
from rest_framework.generics import get_object_or_404
from rest_framework.request import Request
from rest_framework.response import Response
from rest_framework_simplejwt.tokens import RefreshToken
from rest_framework_simplejwt.views import TokenObtainPairView

from django.contrib.auth.models import User

class EmailTokenObtainPairView(TokenObtainPairView):
    def post(self, request: Request) -> Response:
        email: str = request.data.get('email')
        password: str = request.data.get('password')

        user: User | None = User.objects.filter(
            email=email, 
            password=password, 
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
    serializer_class = CartSerializer
    authentication_classes = [JWTAuthentication]
    permission_classes = [IsAuthenticated]