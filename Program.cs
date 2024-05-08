using ClassLibraryLaba10;
using System.Collections;
using System.Numerics;

namespace laba12_4_mycollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyCollection_HashTable<Plants> table = new MyCollection_HashTable<Plants>(10, 0.72);
            int answer;
            do
            {
                Console.WriteLine();
                Console.WriteLine("------ РАБОТА С ХЕШ-ТАБЛИЦЕЙ ------");
                Console.WriteLine("1. Создание хеш-таблицы");
                Console.WriteLine("2. Печать хеш-таблицы");
                Console.WriteLine("3. Добавление элементов в хеш-таблицу ");
                Console.WriteLine("4. Удаление элементов с заданным ключом");
                Console.WriteLine("5. Поиск элемента в хеш-таблице");
                Console.WriteLine("6. Создание глубокой копии");
                Console.WriteLine("7. Создание поверхностной копии");
                Console.WriteLine("8. Использование цикла foreach");
                Console.WriteLine("9. Выход");
                Console.WriteLine();
                answer = InputAnswer();
                Console.WriteLine();
                switch (answer)
                {
                    case 1:
                        table = Сreating();
                        break;
                    case 2: table.Print(); break;
                    case 3:
                        Add(table);
                        break;
                    case 4:
                        Remove(table);
                        break;
                    case 5:
                        Search(table);
                        break;
                    case 6: 
                        Clone(table);
                        break;
                    case 7:
                        Copy(table);
                        break;
                    case 8:
                        if (table.Count == 0)
                        {
                            Console.WriteLine("Таблица пуста. Необходимо добавить элементы перед продолжением.");
                        }
                        foreach (Plants plant in table)
                        {
                            Console.WriteLine(plant);
                        }
                        break;
                    case 9:
                        break;
                    default:
                        {
                            Console.WriteLine("Неправильно задан пункт меню");
                            break;
                        }
                }
            } while (answer != 9);

            Console.ReadLine();
        }

        static int InputAnswer()
        {
            int answer;
            bool Ok;
            do
            {
                string buf = Console.ReadLine();
                Ok = int.TryParse(buf, out answer);
                if (!Ok)
                {
                    Console.WriteLine("Неправильно выбран пункт меню. Повторите ввод");
                }
            } while (!Ok);
            return answer;
        }

        static MyCollection_HashTable<Plants> Сreating()
        {
            MyCollection_HashTable<Plants> table = new MyCollection_HashTable<Plants>(CreatePlant(), CreateTree(), CreateFlower(), CreateRose(), CreatePlant());

            Console.WriteLine("Таблица создана");
            return table;
        }

        static int Menu()
        {
            Console.WriteLine("1. Растение (базовый класс)");
            Console.WriteLine("2. Дерево (производный класс)");
            Console.WriteLine("3. Цветок (производный класс)");
            Console.WriteLine("4. Роза (производный класс)");
            Console.WriteLine("5. Назад");
            Console.WriteLine();
            return InputAnswer();
        }

        static Plants CreatePlant()
        {
            Plants plant = new Plants();
            plant.RandomInit();
            return plant;
        }

        static Trees CreateTree()
        {
            Trees tree = new Trees();
            tree.RandomInit();
            return tree;
        }

        static Flowers CreateFlower()
        {
            Flowers flower = new Flowers();
            flower.RandomInit();
            return flower;
        }

        static Rose CreateRose()
        {
            Rose rose = new Rose();
            rose.RandomInit();
            return rose;
        }

        static MyCollection_HashTable<Plants> Add(MyCollection_HashTable<Plants> table)
        {
            int ans;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Выберите какой элемент вы хотите добавить:");
                ans = Menu();
                Console.WriteLine();
                switch (ans)
                {
                    case 1:
                        Plants plants = new Plants();
                        plants.Init();
                        if (table.Contains(plants))
                        {
                            Console.WriteLine("Элемент с таким значением уже присутствует в таблице");
                        }
                        else
                        {
                            table.AddItem(plants);
                            Console.WriteLine("Растение добавлено");
                        }
                        break;
                    case 2:
                        Trees trees = new Trees();
                        trees.RandomInit();
                        if (table.Contains(trees))
                        {
                            Console.WriteLine("Элемент с таким значением уже присутствует в таблице");
                        }
                        else
                        {
                            table.AddItem(trees);
                            Console.WriteLine("Дерево добавлено");
                        }
                        break;
                    case 3:
                        Flowers flower = new Flowers();
                        flower.RandomInit();
                        if (table.Contains(flower))
                        {
                            Console.WriteLine("Элемент с таким значением уже присутствует в таблице");
                        }
                        else
                        {
                            table.AddItem(flower);
                            Console.WriteLine("Цветок добавлен");
                        }
                        break;
                    case 4:
                        Rose rose = new Rose();
                        rose.RandomInit();
                        if (table.Contains(rose))
                        {
                            Console.WriteLine("Элемент с таким значением уже присутствует в таблице");
                        }
                        else
                        {
                            table.AddItem(rose);
                            Console.WriteLine("Роза добавлена");
                        }
                        break;
                    case 5: break;
                    default:
                        {
                            Console.WriteLine("Неправильно задан пункт меню");
                            break;
                        }
                }
            } while (ans != 5);
            return table;
        }

        static MyCollection_HashTable<Plants> Remove(MyCollection_HashTable<Plants> table)
        {
            if (table.Count == 0)
            {
                Console.WriteLine("Таблица пуста. Необходимо добавить элементы перед продолжением.");
                return table;
            }
            int ans;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Выберите какой элемент вы хотите удалить:");
                ans = Menu();
                Console.WriteLine();
                switch (ans)
                {
                    case 1:
                        RemoveElement(table, CreatePlant());
                        break;
                    case 2:
                        RemoveElement(table, CreateTree());
                        break;
                    case 3:
                        RemoveElement(table, CreateFlower());
                        break;
                    case 4:
                        RemoveElement(table, CreateRose());
                        break;
                    case 5: break;
                    default:
                        {
                            Console.WriteLine("Неправильно задан пункт меню");
                            break;
                        }
                }
            } while (ans != 5);
            return table;
        }

        static bool RemoveElement<T>(MyCollection_HashTable<Plants> table, T element) where T : Plants
        {
            element.Init();
            bool removed = table.RemoveData(element);
            if (removed)
            {
                Console.WriteLine("Элемент удален");
            }
            else
            {
                Console.WriteLine("Элемента нет в таблице");
            }
            return removed;
        }

        static bool SearchElement<T>(MyCollection_HashTable<Plants> table, T element) where T : Plants
        {
            element.Init();
            bool found = table.Contains(element);
            if (found)
            {
                Console.WriteLine("Элемент найден");
            }
            else
            {
                Console.WriteLine("Элемента нет в таблице");
            }
            return found;
        }

        static MyCollection_HashTable<Plants> Search(MyCollection_HashTable<Plants> table)
        {
            if (table.Count == 0)
            {
                Console.WriteLine("Таблица пуста. Необходимо добавить элементы перед продолжением.");
                return table;
            }
            int ans;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Выберите какой элемент вы хотите найти:");
                ans = Menu();
                Console.WriteLine();
                switch (ans)
                {
                    case 1:
                        SearchElement(table, CreatePlant());
                        break;
                    case 2:
                        SearchElement(table, CreateTree());
                        break;
                    case 3:
                        SearchElement(table, CreateFlower());
                        break;
                    case 4:
                        SearchElement(table, CreateRose());
                        break;
                    case 5: break;
                    default:
                        {
                            Console.WriteLine("Неправильно задан пункт меню");
                            break;
                        }
                }
            } while (ans != 5);
            return table;
        }

        static void ModifyAndCheck(MyCollection_HashTable<Plants> table, bool isDeepCopy)
        {
            if (table.Count == 0)
            {
                Console.WriteLine("Таблица пуста. Необходимо добавить элементы перед продолжением.");
                return;
            }

            // Создаем копию или клон таблицы
            MyCollection_HashTable<Plants> copiedTable = isDeepCopy ? table.DeepCopy() : table.CopyTable();

            // Изменяем элементы в исходной таблице
            foreach (Plants item in copiedTable)
            {
                // Изменяем свойства объекта напрямую
                item.Name = "New Name";
                item.Color = "New Color";
            }

            // Проверяем, отразились ли изменения в исходной таблице на скопированной
            bool changesReflected = true;
            foreach (var item in copiedTable)
            {
                // Проверяем, содержит ли скопированная таблица измененные элементы
                if (!table.Contains(item))
                {
                    changesReflected = false;
                    break;
                }
            }

            if (changesReflected)
            {
                Console.WriteLine("Изменения в исходной таблице отразились на скопированной. Это указывает на поверхностное копирование.");
            }
            else
            {
                Console.WriteLine("Изменения в исходной таблице не отразились на скопированной. Это указывает на глубокое копирование.");
            }
        }

        static void Copy(MyCollection_HashTable<Plants> table)
        {
            ModifyAndCheck(table, isDeepCopy: false);
        }

        static void Clone(MyCollection_HashTable<Plants> table)
        {
            ModifyAndCheck(table, isDeepCopy: true);
        }
    }
}
