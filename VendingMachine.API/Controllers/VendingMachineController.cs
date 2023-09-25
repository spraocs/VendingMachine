using Microsoft.AspNetCore.Mvc;
using VendingMachine.API.Models;

namespace VendingMachine.API.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class VendingMachineController : ControllerBase
    {
        public VendingMachineController() 
        {
            VendingMachineDto.GetInstance().UpdateItems();
        }

        [HttpGet]
        public ActionResult<IEnumerable<ItemDto>> GetItems()
        {
            return Ok(VendingMachineDto.GetInstance().Items);
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(int id)
        {
            var item = VendingMachineDto.GetInstance().Items.FirstOrDefault(c => c.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpGet("quantity")]
        public ActionResult<int> GetQuantity()
        {
            return VendingMachineDto.GetInstance().GetQuantity();
        }

        [HttpPost("insertMoney")]
        public void InsertMoney(decimal amount)
        {
            VendingMachineDto.GetInstance().Balance += amount;
        }

        [HttpGet("Balance")]
        public ActionResult<decimal> GetBalance()
        {
            return new JsonResult(VendingMachineDto.GetInstance().Balance);
        }

        [HttpPost("Purchase/{itemcode}")]
        public ActionResult Purchase(int itemcode) 
        {
            var items = new List<ItemDto>();
            items = (List<ItemDto>)VendingMachineDto.GetInstance().Items.Where(c => c.ItemCode == itemcode).ToList();
            if (items.Count == 0)
                return BadRequest("Product is out of Stock");
            var item = items.First();
            if (item == null) 
            {
                return NotFound();
            }
            if (VendingMachineDto.GetInstance().Balance < item.Price)
            {
                return BadRequest("Insufficient Funds");
            }

            VendingMachineDto.GetInstance().Balance -= item.Price;
            VendingMachineDto.GetInstance().RemoveItem(item);
            return Ok();
        }

        [HttpGet("EndTransaction")]
        public ActionResult<decimal> EndTransaction() 
        {
            var change = VendingMachineDto.GetInstance().Balance;
            VendingMachineDto.GetInstance().Balance = 0;
            return change;
        }
    }
}
