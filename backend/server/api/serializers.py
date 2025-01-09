from .models import Cart, Item
from rest_framework import serializers

class ItemSerializer(serializers.ModelSerializer):
    name = serializers.CharField(source='product.name', read_only=True)
    image = serializers.ImageField(source='product.image', read_only=True)

    class Meta:
        model = Item
        fields = ['name', 'image', 'price', 'quantity']

class CartSerializer(serializers.ModelSerializer):
    items = ItemSerializer(many=True, read_only=True)

    class Meta:
        model = Cart
        fields = ['items', 'subtotal']