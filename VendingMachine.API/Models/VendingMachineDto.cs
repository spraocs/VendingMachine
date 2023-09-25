namespace VendingMachine.API.Models
{
    public class VendingMachineDto
    {
        public const int ItemCapacity = 10;
        public const int ItemTypeCapacity = 9;
        private decimal Banalce = 0.0m;
        private static VendingMachineDto? Instance;
        public string Location = string.Empty;
        public List<ItemDto> Items = new();
        public List<ItemTypeDto> ItemTypes = new();

        private VendingMachineDto()
        {
        }

        public static VendingMachineDto GetInstance()
        {
            if (Instance == null)
            {
                Instance = new VendingMachineDto
                {
                    Banalce = 0.0m
                };
            }
            return Instance;
        }

        public decimal Balance
        {
            get { return Banalce; }
            set { Banalce = value; }
        }

        public int GetQuantity()
        {
            if (Items.Any())
            {
                return Items.Count;
            }
            else
                return 0;
        }

        public void RemoveItem(ItemDto item)
        {
            Items.Remove(item);
        }

        public void UpdateItems()
        {
            if (!Items.Any())
            {
                UpdateItemTypes();

                foreach (var itemType in ItemTypes) 
                {
                    for (int i = 0; i < ItemCapacity; i++)
                    {
                        Items.Add(new ItemDto { Id = i, ItemCode = itemType.ItemTypeCode, Name = itemType.Name, Price = 1.00m });
                    }
                }
            }
        }

        private void UpdateItemTypes()
        {
            if (!ItemTypes.Any())
            {
                for (int i = 0; i < ItemTypeCapacity; i++)
                {
                    string ItemTypeName = string.Empty;
                    switch (i)
                    {
                        case 0:
                            ItemTypeName = "Coke";
                            break;
                        case 1:
                            ItemTypeName = "Pepsi";
                            break;
                        case 2:
                            ItemTypeName = "Fanta";
                            break;
                        case 3:
                            ItemTypeName = "Water";
                            break;
                        case 4:
                            ItemTypeName = "Chips";
                            break;
                        case 5:
                            ItemTypeName = "Doritos";
                            break;
                        case 6:
                            ItemTypeName = "FigBar";
                            break;
                        case 7:
                            ItemTypeName = "FairLife";
                            break;
                        case 8:
                            ItemTypeName = "AlmondJoy";
                            break;
                        default:
                            break;
                    }

                    ItemTypes.Add(new ItemTypeDto { Id = Guid.NewGuid(), ItemTypeCode = i, Name = ItemTypeName });
                }
            }
        }
    }
}
