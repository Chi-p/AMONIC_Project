# AMONIC_Project
***
## ENG

### Manage flight schedules
When you launch the app, you are taken to the Manage Flight Schedules page.
![image](https://user-images.githubusercontent.com/52102133/112291371-1aab7680-8ca1-11eb-8163-8a812926cc1e.png)

In the central part of the window there is a table with flight schedules. Here you can see: departure date, departure time, IATA departure airport, IATA arrival airport, flight number, prices in Economy class, Business class and first class. The red lines indicate that the flight was canceled, and the white lines indicate that the flight was successful.

In the upper part of the window, there is a group of elements that are responsible for filtering data in the table. Here you can select: airport (from and to), departure date, flight number, and sort the table by a specific column. To sort the data, click the "Apply" button. To clear the filter settings, click on the "Clear" button.

There are several buttons at the bottom of the window:
* Enable/Cancel Flight, default: Select a row;
* Edit flight;
* Import changes.

To enable or disable the flight, first select a row in the table and then click on the "Enable/Cancel flight" button. The line you selected will change color to white or red after clicking on the button(see the description of colors above), depending on the initial state.

To edit a flight, first select a row in the table and then click on the "Edit Flight" button. After that, you will open a new window "Edit flight".
![image](https://user-images.githubusercontent.com/52102133/112291405-239c4800-8ca1-11eb-8edc-7e8094212ddb.png)

At the top of the window, you can see a group of data displaying information about the selected flight: IATA departure airport, IATA arrival airport, and the name of the aircraft.
At the bottom of the window, you can change the departure date, time, and price in Economy Class. To save the changes, click the "Update" button. To cancel and close the window, click the "Cancel" button.

To import the data, click on the "Import changes" button. After that, you will see a new window "Apply Schedule Changes".
![image](https://user-images.githubusercontent.com/52102133/112291951-a7563480-8ca1-11eb-96ce-234186cca89c.png)

In the upper part of the window there is a text field and the "Import changes" button. To select the desired file, you need to start on the text field that opens the file selection dialog box (.csv format). After that, click on the "Import changes" button. At the bottom of the window, you can see the results of the import:
* Successful Changes Applied
* Duplicate Records Discarded
* Record with missing fields Discarded
***
## RUS

### Управление расписанием рейсов
При запуске приложения вы попадаете на страницу управления расписанием рейсов (Manage Flight Schedules).

![image](https://user-images.githubusercontent.com/52102133/112291371-1aab7680-8ca1-11eb-8163-8a812926cc1e.png)

В центральной части окна располагается таблица с расписаниями рейсов. Здесь вы можете увидеть: дату вылета, время вылета, IATA аэропорта вылета, IATA аэропорта прибытия, номер рейса, цены в эконом-классе, бизнес-классе и в первом классе. Строки красного цвета означают, что данный полёт был отменён, белый - полёт прошёл успешно.

В верхней части окна расположена группа элементов, отвечающих за фильтрацию данных в таблице. Здесь можно выбрать: аэропорт(откуда и куда), дату вылета, номер рейса, а также отсортировать таблицу по определённой колонке. Чтобы отсортировать данные, необходимо нажать кнопку "Применить" (Apply). Чтобы очистить настройки фильтрации, необходимо нажать на кнопку "Очистить" (Clear).

В нижней части окна располагаются несколько кнопок:
* Включить/Отменить полёт, по умолчанию: выберите строку (Enable/Cancel Flight, default: Select a row);
* Редактировать полёт (Edit flight);
* Импортировать изменения (Import changes).

Чтобы включить или же выключить полёт, сперва необходимо выбрать строку в таблице и затем нажать на кнопку "Включить/Отменить полёт". Выбранная вами строка после нажатия на кнопку поменяет цвет на белый или красный(описание цветов смотреть выше), в зависимости от первоначального состояния.

Для редактирования полёта сперва необходимо выбрать строку в таблице и затем нажать на кнопку "Редактировать полёт". После этого у вас откроется новое окно "Редактировать полёт" (Edit flight).

![image](https://user-images.githubusercontent.com/52102133/112291405-239c4800-8ca1-11eb-8edc-7e8094212ddb.png)

В верхней части окна вы можете увидеть группу данных, отображающих информацию о выбранном полёте: IATA аэропорта вылета, IATA аэропорта прибытия и название самолёта.
В нижней части окна вы можете изменить дату вылета, время и цену в эконом-классе. Чтобы сохранить изменения необходимо нажать кнопку "Обновить" (Update). Чтобы отменить и закрыть окно - нажмите кнопку "Отменить" (Cancel).

Для импортирования данных необходимо нажать на кнопку "Импортировать изменения". После этого у вас откроется новое окно "Применить изменения в расписании" (Apply Schedule Changes).

![image](https://user-images.githubusercontent.com/52102133/112291951-a7563480-8ca1-11eb-96ce-234186cca89c.png)

В верхней части окна располагается текстовое поле и кнопка "Импортировать изменения" (Import changes). Чтобы выбрать необходимый файл, нужно начать на текстовое поле, которое открывает диалоговое окно выбора файла(формат .csv). После этого необходимо нажать на кнопку "Импортировать изменения". В нижней части окна вы можете увидеть результаты импортирования:
* Успешно применённые изменения (Successful Changes Applied)
* Отброшенные дубликаты записей (Duplicate Records Discarded)
* Отброшенные записи с отсутствующими полями (Record with missing fields Discarded)
