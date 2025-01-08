from django.db import models

SUBTOTAL_DECIMAL_PLACES = 2
SUBTOTAL_MAX_DIGITS = 10
SUBTOTAL_DEFAULT = 0

PRODUCT_NAME_MAX_LENGTH = 50
CATEGORY_NAME_MAX_LENGTH = 25

class Categories(models.TextChoices):
    SALAD = 'Salad', 'Salad'
    PIZZA = 'Pizza', 'Pizza'
    SUSHI = 'Sushi', 'Sushi'
    GRILL = 'Grill', 'Grill'
    BURGER = 'Burger', 'Burger'
    PASTA = 'Pasta', 'Pasta'
    DESSERT = 'Dessert', 'Dessert'
    DRINK = 'Drink', 'Drink'

BASE_PRICE_MAX_DIGITS = 5
BASE_PRICE_DECIMAL_PLACES = 2
BASE_PRICE_MIN_VALUE = 0

DISCOUNT_PERCENTAGE_DEFAULT = 0
DISCOUNT_PERCENTAGE_MIN_VALUE = 0
DISCOUNT_PERCENTAGE_MAX_VALUE = 100

IMAGE_UPLOAD_DIRECTORY = 'products/'

QUANTITY_DEFAULT = 1
CART_RELATED_NAME = 'items'