namespace GroupPreOrderApi.Models;

// 1. Модель блюда
public class DishDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}

// 2. Позиция в заказе (блюдо + количество)
public class OrderItemDto
{
    public DishDto Dish { get; set; } = new();
    public int Quantity { get; set; }
}

// 3. Модель участника (сессия гостя)
public class ParticipantDto
{
    public string Id { get; set; } = string.Empty;
    public string Type { get; set; } = "Guest";
    public string Name { get; set; } = string.Empty;
    public List<OrderItemDto> Items { get; set; } = new();

    // Автоматический расчет суммы по участнику: цена * количество
    public decimal Total => Items.Sum(i => i.Dish.Price * i.Quantity);

    public bool IsSubmitted { get; set; }
}

// 4. Итоговая модель ответа для Owner
public class GroupSessionsResponseDto
{
    public List<ParticipantDto> Participants { get; set; } = new();

    // Автоматический расчет общей суммы по всем участникам
    public decimal Total => Participants.Sum(p => p.Total);
}