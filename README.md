# cryptography-kata
Шифр Цезаря с кириллицей (Caeser cipher)
------------------------------------------
Задача 1
Дано слово на русском языке и ключ. Зашифруйте данное слово с данным
ключом при помощи шифра Цезаря. Считайте, что в алфавите присутствуют
все 33 буквы (ё, й и т.д.).
Слово=автомобиль, Ключ=18.

Задача 2
Дана криптограмма, полученная при помощи шифра Цезаря после зашифрования
слова на русском языке, и ключ. Расшифруйте данную криптограмму с данным
ключом. 
Криптограмма=аыпьэщчкэуй, Ключ=11.

Задача 3
Дано слово на русском языке и соответствующая ему криптограмма.
Проведите атаку по известному открытому тексту. 
Слово=уязвимость, Криптограмма=якунфшъэюз.

Задача 4
Дана криптограмма, полученная после зашифрования русского слова шифром Цезаря.
Методом полного перебора ключей (методом грубой силы) найдите исходный открытый
текст и ключ, который был использован при зашифровании. 
Криптограмма=ойюклзёщлвш.

![изображение](https://user-images.githubusercontent.com/92585647/168518225-eb0ec273-11b4-4ff9-9254-ef558e5aad0d.png)



Симметричные шифры (Symmetric ciphers)
------------------------------------------
Задача 1 
Даны 3 восьмибитовых числа открытого текста и 3 числа, представляющие собой ключ.
Требуется перевести эти числа в двоичный вид, зашифровать шифром Вернама
и перевести обратно в десятичный. В решении задачи двоичный вид должен быть приведен.
n1=73, n2=216, n3=4, k1=30, k2=57, k3=109.

Задача 2
Даны параметры линейного конгруэнтного генератора псевдослучайных чисел. Сгенерируйте с помощью этого генератора 10 псевдослучайных чисел.
a=2916, b=1068, c=3869, x0=3641.

Задача 3
Даны параметры поточного шифра RC4. Сгенерируйте 8 чисел.
Приведите все промежуточные действия (i, j, t, перестановку).
n=3, S=25031476.

Задача 4
Даны параметры поточного шифра RC4. Сформируйте начальную перестановку.
Приведите все промежуточные действия (i, j, перестановку).
n=3, L=3, K0=0, K1=4, K2=4.

![изображение](https://user-images.githubusercontent.com/92585647/168984874-8dc944b8-84b6-40fa-932c-c141ab968974.png)



Односторонние функции
------------------------------------------
Задача 1
Даны параметры a, x и p. Вычислите значение функции a^x mod p, используя алгоритм
быстрого возведения в степень. Подробно распишите все промежуточные действия.
a=9, x=932, p=11.

Задача 2
Дано значение параметра p. Оцените сложность (число операций умножения)
вычисления прямой (при помощи алгоритма быстрого возведения в степень по модулю)
и обратной функции (методами полного перебора и "Шаг младенца - Шаг великана")
a^x mod p при таком значении p. Считайте, что параметры a и x могут быть
произвольными из диапазона от 2 до p-1.
p=40297000000.

Задача 3
Дано число абонентов сети (N). Найдите количество секретных ключей,
необходимых для того, чтобы все абоненты могли общаться друг с другом
попарно безопасно.
N=11898.

Задача 4
Даны некоторые из параметров системы Диффи-Хеллмана для трех абонентов. Вычислите
недостающие параметры и сформируйте ключи для каждой пары абонентов.
p=23, g=17, Xa=22, Xb=5, Xc=4.

Задача 5
Дано число p. Найдите все подходящие значения параметра g для системы Диффи-Хеллмана.
Если p>11, то найдите не все, а только два значения.
p=11.


Хеш функции (MD5_HashFunc)
------------------------------------------
Задача 1 Реализуйте или возьмите готовую реализацию любой криптографической хеш-функции; 
допускается реализация криптографической хеш-функции на базе любого блочного шифра.

Задача 2 С использованием хеш-функции, полученной в предыдущем пункте, выполните одно любое задание на выбор:
* Реализуйте поиск частичных коллизий хеш-функции.
* Реализуйте генерацию псевдослучайных чисел с помощью хеш-функции.

![изображение](https://user-images.githubusercontent.com/92585647/170454693-26fcabcd-bba6-42ce-88ab-059084910b9d.png)

------------------------------------------
