﻿using System.Threading.Tasks;
using MicroservicesApp.Services.ShoppingCartAPI.Models.Dto;

namespace MicroservicesApp.Services.ShoppingCartAPI.Repository
{
    public interface ICartRepository
    {
        Task<CartDto> GetCartByUserId(string userId);
        Task<CartDto> CreateUpdateCart(CartDto cartDto);
        Task<bool> RemoveFromCart(int cartDetailsId);
        Task<bool> ClearCart(string userId);
    }
}
