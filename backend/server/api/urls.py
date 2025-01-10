from django.urls import include, path
from rest_framework_simplejwt.views import TokenObtainPairView, TokenRefreshView

from .views import CookieTokenObtainPairView, CookieTokenRefreshView, AddToCartCreateAPIView, CartRetrieveAPIView, ProductsRetrieveAPIView, RemoveFromCartDestroyAPIView, UserCreateAPIView

urlpatterns = [
    path('auth/', include([
        path('signup/', UserCreateAPIView.as_view(), name='signup'),
        path('token/', include([
            path('', CookieTokenObtainPairView.as_view(), name='token_obtain_pair'),
            path('refresh/', CookieTokenRefreshView.as_view(), name='token_refresh'),
        ])),
    ])),
    path('cart/', include([
        path('', CartRetrieveAPIView.as_view(), name='cart'),
        path('add/', AddToCartCreateAPIView.as_view(), name='add_to_cart'),
        path('remove/<int:pk>/', RemoveFromCartDestroyAPIView.as_view(), name='remove_from_cart'),
    ])),
    path('products/', ProductsRetrieveAPIView.as_view(), name='products'),
]