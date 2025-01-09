from django.contrib import admin

from .models import Cart, Category, Item, Product

@admin.register(Product)
class ProductAdmin(admin.ModelAdmin):
    list_display = ('name', 'category', 'base_price', 'discount_percentage', 'price', 'image', 'date_added')

@admin.register(Item)
class ItemAdmin(admin.ModelAdmin):
    list_display = ('product', 'product__image', 'quantity', 'cart', 'price')

@admin.register(Category)
class CategoryAdmin(admin.ModelAdmin):
    list_display = ('name',)

@admin.register(Cart)
class CartAdmin(admin.ModelAdmin):
    list_display = ('user', 'subtotal')