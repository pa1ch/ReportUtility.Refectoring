# Что было отрефакторено:

1. Заменил метод ```PrintReport``` в классе ```Program``` на несколько мини классов-билдеров (```DataRowBuilder```, ```HeaderRowBuilder```, ```RowTemplateBuilder```), класс-директор для билдеров (```RowBuilderDirector```) и глобальный класс-билдер (```ReportBuilder```), который агрегирует все возвращаемые значения мини-билдеров. Таким образом удалось добиться более прозрачного и настраиваемого вывода репорта на консоль.

2. Реализовал паттерн ```ChainOfResponsibility```. Для этого расширил функционал ```ReportService```'ов и написал класс-клиент  ```ExtensionHandler```, который соединяет в цепочку конкретные хендлеры. Заменил вызов методов ```GetReportService``` и ```CreateReport``` в классе ```Program```, вызовом метода ```CreateReport``` нового класса ```ExtensionHandler```. Таким образом облегчил дальнейшее внедрение обработки новых расширений файлов

3. Выполнил пожелания пользователей и сделал возможность убирать из отчёта столбцы «Объём упаковки», «Масса упаковки», «Стоимость», «Количество» за это отвечают агрументы запуска "```-withoutVolume```", "```-withoutWeigth```", "```-withoutCost```", "```-withoutCount```"

4. Выполнил пожелание пользователей, когда указан один из флагов «```withIndex```», «```withTotalVolume```» «```withTotalWeight```», но не указан «```data```» - выводится жёлтым цветом "WARNING"