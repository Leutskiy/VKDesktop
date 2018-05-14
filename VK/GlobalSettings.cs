namespace VK
{
    /// <summary>
    /// Настройки приложения
    /// </summary>
    public static class GlobalSettings
    {
        /// <summary>
        /// Идентификатор приложения
        /// </summary>
        public static string AppId { get; set; }

        /// <summary>
        /// Номер телефона или email
        /// </summary>
        public static string Login => @"dzhon.argentum@mail.ru";

        /// <summary>
        /// Пароль
        /// </summary>
        public static string Password => @"WESTall89";

        public static string Token { get; set; }
    }
}