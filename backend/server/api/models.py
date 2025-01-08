from decimal import Decimal
from django.db import models
from django.contrib.auth.models import User
from django.core.validators import MinValueValidator, MaxValueValidator

from .constraints import Categories

class Cart(models.Model):
    user = models.OneToOneField(to=User, on_delete=models.CASCADE)
    subtotal = models.DecimalField(max_digits=100, decimal_places=2, default=0)

    @property
    def items(self) -> int:
        return self.items.count()

class Product(models.Model):
    name = models.CharField(
        max_length=50
    )

    category = models.CharField(
        max_length=25,
        choices=Categories.choices
    )

    base_price = models.DecimalField(
        max_digits=5,
        decimal_places=2,
        validators=[MinValueValidator(1)]
    )

    discount_percentage = models.PositiveSmallIntegerField(
        default=0,
        validators=[
            MinValueValidator(0),
            MaxValueValidator(100)
        ]
    )

    image = models.ImageField(
        upload_to='products/'
    )

    date_added = models.DateTimeField(
        auto_now_add=True,
        editable=False
    )

    @property
    def price(self) -> Decimal:
        return self.base_price * 1 - (Decimal(self.discount_percentage) / 100)
    
    def __str__(self) -> str:
        return self.name
    
class Item(models.Model):
    product = models.ForeignKey(to=Product, on_delete=models.CASCADE)
    quantity = models.PositiveSmallIntegerField()
    cart = models.ForeignKey(to=Cart, on_delete=models.CASCADE, related_name='items')

    @property
    def price(self) -> Decimal:
        return self.product.price * self.quantity

