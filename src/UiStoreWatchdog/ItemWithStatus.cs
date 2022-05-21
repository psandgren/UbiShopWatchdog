namespace UiStoreWatchdog
{
    public class ItemWithStatus : Item
    {
        public ItemWithStatus()
        {
        }

        public ItemWithStatus(Item item)
        {
            Name = item.Name;
            Url = item.Url;
            NotificationsActive = item.NotificationsActive;
        }

        public string? Status { get; set; }
    }
}
