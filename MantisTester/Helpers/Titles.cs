using MantisTester.Models;
using System.Collections.Generic;

namespace MantisTester.Helpers
{
    public static class Titles
    {
        public static class MenuTitles
        {
            public static readonly string review = "обзор";
            public static readonly string taskList = "список задач";
            public static readonly string magazine = "журнал";
            public static readonly string plan = "план";
            public static readonly string statistics = "статистика";
            public static readonly string control = "управление";
            public static readonly string user = "пользователь";
            public static readonly string exit = "выход";
        }

        public static class ManagementMenuTitles
        {
            public static readonly string user = "Управление пользователями";
            public static readonly string project = "Управление проектами";
            public static readonly string tags = "Управление метками";
            public static readonly string customfFelds = "Управление настраиваемыми полями";
            public static readonly string globalProfile = "Управление глобальными профилями";
            public static readonly string plugin = "Управление плагинами";
            public static readonly string configuration = "Управление конфигурацией";
        }

        public static IdNameDictonary ProjectStatusTitles = new IdNameDictonary()
        {
            { 10, "в разработке" },
            { 30, "выпущен" },
            { 50, "стабильный"},
            { 70, "устарел"}
        };

        public static IdNameDictonary ProjectVisibilityTitles = new IdNameDictonary()
        {
            { 10, "публичная" },
            { 50, "приватная" }
        };

        public static IdNameDictonary ProjectVisibilityTableTitles = new IdNameDictonary()
        {
            { 10, "публичный" },
            { 50, "приватный" }
        };
    }
}