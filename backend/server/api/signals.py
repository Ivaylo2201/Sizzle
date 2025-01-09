from django.contrib.auth.models import User
from django.db.models import F, Sum, QuerySet
from django.dispatch import receiver
from django.db.models.signals import post_delete, post_save

from .models import Cart, Item

@receiver(post_save, sender=User)
def create_cart(sender, instance: User, created: bool, **kwargs) -> None:
    if created:
        Cart.objects.create(user=instance)

@receiver(post_delete, sender=Item)
@receiver(post_save, sender=Item)
def calculate_subtotal(sender, instance: Item, **kwargs) -> None:
    cart: Cart = instance.cart
    items: QuerySet[Item] = cart.items.all()

    cart.subtotal = items.aggregate(total=Sum('price'))['total'] or 0
    cart.save()