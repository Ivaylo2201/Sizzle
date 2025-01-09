from django.urls import include, path
from rest_framework_simplejwt.views import TokenRefreshView

from .views import AddToCartCreateAPIView, CartRetrieveAPIView, EmailTokenObtainPairView, ProductsRetrieveAPIView, UserCreateAPIView

urlpatterns = [
    path('auth/signup/', UserCreateAPIView.as_view(), name='signup'),
    path('auth/token/', include([
        path('', EmailTokenObtainPairView.as_view(), name='token_obtain_pair'),
        path('refresh/', TokenRefreshView.as_view(), name='token_refresh'),
    ])),
    path('cart/', include([
        path('', CartRetrieveAPIView.as_view(), name='cart'),
        path('add/', AddToCartCreateAPIView.as_view(), name='add_to_cart'),
    ])),
    path('products/', ProductsRetrieveAPIView.as_view(), name='products'),
]