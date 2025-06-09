using Core.Entities;
using Core.Interfaces.Generic;

namespace Core.Interfaces.Repositories;

public interface ICartRepository : 
    ICreatable<Cart>, 
    ISingleReadable<Cart, int>;