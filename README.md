# ITMO_project: part_1, part_2
## Кратко о программе
Целью работы была разработка программного обеспечения (клиента), реализующего прием и обработку данных, переданных с гидролокационной станции после проведения натурных испытаний. Информация в гидролокационном модуле считываются с микросхемы Flash-памяти – ее объем может составлять до 15ГБ – передается на компьютер по локальной сети и сохраняется в базе данных. Данные представляют собой временные отсчеты сигналов, снятых с 48 элементов антенны, а также рассчитанных на их основе двух лучей – до 120 млн. отсчетов на каждый сигнал. Каждый пересылаемый по сети пакет соответствует отдельному отсчету времени. Также передаются значения глубины, на которой в различные моменты времени находилась станция в ходе испытаний. 

В работе использованы следующие технологии:
- клиент-серверное приложение на C#;
- организована работа клиентского Windows-приложения с базой данных (БД), реализованной средствами СУБД SQL Server в рамках технологии ADO.NET.

Так как при разработке ПО возможности использовать оборудование не было, то для отладки работы клиента была разработана вспомогательная программа Server, которая по нажатию кнопки «Начать» подключалась к файлу Excel (в открывшемся окне нужно выбрать файл Data.xlsx) и после подключения клиента и передачи на сервер команды «4» считывала из файла данные, аналогичные требуемым, и передавала их клиенту.

Чтобы запустить ПО на другом ПК нужно иметь установленный СУБД SQL Server, поменять в программе характеристики сервера на свои. ПО делала на Win7, запускала потом на Win10.

В представленном ПО есть еще множество возможностей для улучшений.

 
## Функции системы

Модель статической структуры разрабатываемой программной системы представлена на диаграмме классов на рисунке 1.

![Иллюстрация к проекту](https://github.com/LanaLight2020/ITMO_project_part_1/blob/master/pictures/%D1%80%D0%B8%D1%81.1%20%D0%B4%D0%B8%D0%B0%D0%B3%D1%80%D0%B0%D0%BC%D0%BC%D0%B0%20%D0%BA%D0%BB%D0%B0%D1%81%D1%81%D0%BE%D0%B2.jpg) 
Рисунок 1. Диаграмма классов программного обеспечения, реализующего прием и обработку данных, переданных с сервера

Диаграмма классов включает три объекта:
1. Form1 – визуализация пользовательского интерфейса;
2. DataBaseLoading – прием данных с сервера и сохранение их в таблице базы данных;
3. Pannel1 – извлечение из БД информации по запрошенному пользователем каналу и создание графических объектов (Chart) с изображением сигнала во временной и частотной областях.

 Объект DataBaseLoading содержит три метода:
1. DataBaseCreating()  - создает новую БД и таблицу в ней с заранее определенными полями, которые соответствуют данным, ожидаемым с гидролокационной станции, вызывается в конструкторе класса DataBaseLoading;
2. DataBaseFilling() – открывает соединение с БД, вставляет строку с данными, закрывает соединение с БД;
3. ReadLoadData() – устанавливает соединение с сервером; посылает запрос на подачу данных; принимает данные с сервера и записывает их в БД с помощью метода DataBaseFilling().

Объект Pannel1 также содержит три метода:
1. drawGraphic()  - создает графический объект  (Chart) на основе двух массивов, представляющих собой отсчеты по горизонтальной и вертикальной осям графика;
2. getColumnFromDB()  -  открывает соединение с БД, запрашивает данные по выбранному пользователем столбцу, создает графический объект с помощью метода drawGraphic(), закрывает соединение с БД;
3. countFFT()  - считает быстрое преобразование Фурье для выбранного в методе getColumnFromDB() и сохраненного в поле chY сигнала (набора точек), создает графический объект с помощью метода drawGraphic().

## Описание системы

Работа с окном приложения позволяет выполнять следующие действия:
1. Создание БД, таблицы, заполнение таблицы данными, принятыми от сервера. 
Пользователь задает в текстовом поле имя базы данных или оставляет предложенное по умолчанию и нажимает на кнопку «Создание БД/ загрузка данных» - создается объект типа DataBaseLoading и вызывается его метод ReadLoadData(). 

 ![Иллюстрация к проекту](https://github.com/LanaLight2020/ITMO_project_part_1/blob/master/pictures/im2_window.jpg)

Рисунок 2. Окно приложения пользователя программы приема и обработки данных, переданных с сервера
 
![Иллюстрация к проекту](https://github.com/LanaLight2020/ITMO_project_part_1/blob/master/pictures/im3_table.jpg)
Рисунок 3. Таблица userData с заполненными полями

В результате создается БД с именем, указанным пользователем, в этой БД создается таблица userData с полями, которые соответствуют данным, ожидаемым с сервера (рисунок 3). Названия и характеристики полей представлены в таблице ниже.


### Поля таблицы userData

  1	ID	-	Номер строки по порядку, до 120 млн. строк

  2-49	Ch_1… Ch_48	-	Отсчеты сигналов, снятых с 48-ми элементов антенны

  50-51	Beam_1, Beam_2 	-	Отсчеты двух лучей, рассчитанных на основе сигналов с элементов антенны

  52	Deep	-	Значения глубины, на которой находилась станция в ходе испытаний, не больше 255 м

Клиент-приложение посылает запрос на соединение с сервером, который находится в режиме ожидания. После установки соединения клиентское приложение отсылает серверу запрос на передачу данных (число «4»). В ответ на запрос сервер начинает считывать данные, записанные в Excel, и инициализирует их передачу по сети клиенту. Программа на стороне клиента принимает поступающую информацию и записывает ее в таблицу созданной базы данных (рисунок 3).

2. Вывод записанных в БД сигналов в графическом виде.

2.1. Реализация анализа отдельных сигналов.

На вкладке «Анализ отдельных сигналов» (Рисунок 2) пользователь выбирает элемент антенны, сигнал с которого он хотел бы вывести на график, нажимает кнопку «Построить» - в результате создается объект типа Pannel1 и вызывается его метод getColumnFromDB() -  выводится изображение сигнала в диапазоне, заданном в полях под графиком. При желании пользователь может скорректировать рассматриваемый диапазон и снова нажать на кнопку «Построить» - на графике будет отображен сигнал, соответствующий заданным рамкам.

Для выбранного диапазона сигнала программа позволяет построить АЧХ – достаточно нажать кнопку «Построить», расположенную рядом с графиком «Спектр выбранного сигнала» - для ранее созданного в методе getColumnFromDB() объекта типа Pannel1 вызывается метод countFFT().
