from decimal import Decimal
from django.db import models
from django.contrib.auth.models import User
from django.core.validators import MinValueValidator, MaxValueValidator

from .constraints import (
    BASE_PRICE_DECIMAL_PLACES, 
    BASE_PRICE_MAX_DIGITS, 
    BASE_PRICE_MIN_VALUE, 
    CART_RELATED_NAME, 
    CATEGORY_NAME_MAX_LENGTH, 
    DISCOUNT_PERCENTAGE_DEFAULT, 
    DISCOUNT_PERCENTAGE_MAX_VALUE, 
    DISCOUNT_PERCENTAGE_MIN_VALUE, 
    IMAGE_UPLOAD_DIRECTORY, 
    PRODUCT_NAME_MAX_LENGTH, 
    QUANTITY_DEFAULT, 
    SUBTOTAL_DECIMAL_PLACES, 
    SUBTOTAL_DEFAULT, 
    SUBTOTAL_MAX_DIGITS, 
    Categories
)

class Cart(models.Model):
    user = models.OneToOneField(to=User, on_delete=models.CASCADE)

    subtotal = models.DecimalField(
        max_digits=SUBTOTAL_MAX_DIGITS, 
        decimal_places=SUBTOTAL_DECIMAL_PLACES, 
        default=SUBTOTAL_DEFAULT
    )

class Category(models.Model):
    name = models.CharField(
        max_length=CATEGORY_NAME_MAX_LENGTH, 
        choices=Categories.choices
    )

class Product(models.Model):
    name = models.CharField(max_length=PRODUCT_NAME_MAX_LENGTH)

    category = models.ForeignKey(
        to=Category, 
        on_delete=models.CASCADE
    )

    base_price = models.DecimalField(
        max_digits=BASE_PRICE_MAX_DIGITS,
        decimal_places=BASE_PRICE_DECIMAL_PLACES,
        validators=[MinValueValidator(BASE_PRICE_MIN_VALUE)]
    )

    discount_percentage = models.PositiveSmallIntegerField(
        default=DISCOUNT_PERCENTAGE_DEFAULT,
        validators=[
            MinValueValidator(DISCOUNT_PERCENTAGE_MIN_VALUE),
            MaxValueValidator(DISCOUNT_PERCENTAGE_MAX_VALUE)
        ]
    )

    image = models.ImageField(upload_to=IMAGE_UPLOAD_DIRECTORY)

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
    product = models.ForeignKey(
        to=Product, 
        on_delete=models.CASCADE
    )

    quantity = models.PositiveSmallIntegerField(default=QUANTITY_DEFAULT)

    cart = models.ForeignKey(
        to=Cart, 
        on_delete=models.CASCADE, 
        related_name=CART_RELATED_NAME
    )

    @property
    def price(self) -> Decimal:
        return self.product.price * self.quantity

