from django.contrib.auth.models import User
from django.db.models import Sum
from django.dispatch import receiver
from django.db.models.signals import post_delete, post_save

from .models import Cart, Item

@receiver(post_save, sender=User)
def create_cart(_, instance: User, created: bool):
    if created:
        Cart.objects.create(user=instance)

@receiver(post_delete, sender=Item)
@receiver(post_save, sender=Item)
def calculate_subtotal(_, instance: Item):
    cart: Cart = instance.cart
    subtotal = cart.items.aggregate(total=Sum('price'))['total'] or 0
    cart.subtotal = subtotal
    cart.save()