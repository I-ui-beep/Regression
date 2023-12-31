Было разработано консольное приложение на языке C#, которое рассчитывает коэффициенты множественной линейной регрессии для двух влияющих факторов и одного результативного. Приложение максимально сокращает время и предотвращает возможности совершения ошибок при ручном расчете.

Основная **цель** множественной регрессии – построить модель с большим числом факторов, определив при этом влияние каждого из них в отдельности, а также совокупное их воздействие на моделируемый показатель.
Суть определения степени влияния заключается в вычислении значений коэффициентов, используя исходные данные или, что эквивалентно, матрицу плана. В проекте применяется метод, называемый обращением матрицы в замкнутой форме, также известный как обычный **метод наименьших квадратов (МНК)**.

После получения исходных данных, строится система линейных уравнений с неизвестными коэффициентами (b<sub>0</sub>, b<sub>1</sub>, b<sub>2</sub>):

✏∑y<sub>i</sub>=nb<sub>0</sub>+b<sub>1</sub>∑x<sub>1i</sub>+b<sub>2</sub>∑x<sub>2i</sub>,

✏∑x<sub>1i</sub>y<sub>i</sub> =b<sub>0</sub>∑x<sub>1i</sub>+b<sub>1</sub>∑x<sub>1i</sub><sup>2</sup>+b<sub>2</sub>∑x<sub>1i</sub>x<sub>2i</sub>,

✏∑x<sub>2i</sub>y<sub>i</sub> = b<sub>0</sub>∑x<sub>2i</sub> + b<sub>1</sub>∑x<sub>1i</sub>x<sub>2i</sub> + b<sub>2</sub>∑x<sub>2i</sub><sup>2</sup>.


Далее для решения системы применяется **метод Крамера**, основанный на использовании определителей. Если основной определитель системы не равен нулю, то данная система линейных уравнений имеет одно единственное решение, для которого необходимо вычислить определители при неизвестных (∆<sub>1</sub>, ∆<sub>2</sub>, ∆<sub>3</sub>), которые, вследствие деления на основной определитель, образуют искомые коэффициенты регрессии.
