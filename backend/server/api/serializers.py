from .models import Cart, Item, Product
from rest_framework import serializers

class ProductSerializer(serializers.ModelSerializer):
    class Meta:
        model = Product
        fields = ['pk', 'name', 'base_price', 'discount_percentage', 'image', 'price']

class ItemSerializer(serializers.ModelSerializer):
    name = serializers.CharField(source='product.name', read_only=True)
    image = serializers.ImageField(source='product.image', read_only=True)

    class Meta:
        model = Item
        fields = ['pk', 'name', 'image', 'price', 'quantity']

class CartSerializer(serializers.ModelSerializer):
    items = ItemSerializer(many=True, read_only=True)

    class Meta:
        model = Cart
        fields = ['items', 'subtotal']