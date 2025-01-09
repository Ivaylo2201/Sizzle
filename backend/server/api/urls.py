from django.urls import include, path
from rest_framework_simplejwt.views import TokenRefreshView

from .views import CartRetrieveAPIView, EmailTokenObtainPairView

urlpatterns = [
    path('auth/token/', include([
        path('', EmailTokenObtainPairView.as_view(), name='token_obtain_pair'),
        path('refresh/', TokenRefreshView.as_view(), name='token_refresh'),
    ])),
    path('cart/', include([
        path('', CartRetrieveAPIView.as_view(), name='cart'),
    ]))
]