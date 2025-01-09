from decimal import ROUND_DOWN, Decimal
from django.db import models
from django.contrib.auth.models import User
from django.core.validators import MinValueValidator, MaxValueValidator

from .constraints import (
    PRICE_DECIMAL_PLACES, 
    PRICE_MAX_DIGITS, 
    PRICE_MIN_VALUE, 
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
    
    def __str__(self) -> str:
        return f'Cart for {self.user.email}'

class Category(models.Model):
    name = models.CharField(
        max_length=CATEGORY_NAME_MAX_LENGTH, 
        choices=Categories.choices
    )

    def __str__(self) -> str:
        return self.name

class Product(models.Model):
    name = models.CharField(max_length=PRODUCT_NAME_MAX_LENGTH)

    category = models.ForeignKey(
        to=Category, 
        on_delete=models.CASCADE
    )

    base_price = models.DecimalField(
        max_digits=PRICE_MAX_DIGITS,
        decimal_places=PRICE_DECIMAL_PLACES,
        validators=[MinValueValidator(PRICE_MIN_VALUE)]
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

    price = models.DecimalField(
        null=True,
        blank=True,
        editable=False,
        max_digits=PRICE_MAX_DIGITS,
        decimal_places=PRICE_DECIMAL_PLACES
    )

    def save(self, *args, **kwargs) -> None:
        self.price = (
            self.base_price * (1 - (Decimal(self.discount_percentage) / 100))).quantize(Decimal('0.00'), rounding=ROUND_DOWN
        )
        super().save(*args, **kwargs)
    
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

    price = models.DecimalField(
        null=True,
        blank=True,
        editable=False,
        max_digits=PRICE_MAX_DIGITS,
        decimal_places=PRICE_DECIMAL_PLACES
    )

    def save(self, *args, **kwargs) -> None:
        self.price = self.product.price * self.quantity
        return super().save(*args, **kwargs)   


