using Core.Entities;
using Core.Interfaces.Generic;

namespace Core.Interfaces.Repositories;

public interface IProductRepository : ISingleReadable<Product, Guid>, IMultipleReadable<Product>;