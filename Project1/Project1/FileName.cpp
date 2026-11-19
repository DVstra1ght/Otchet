#include <iostream>
#include <cstdlib>
#include <ctime>
#include <stdexcept> // Для работы с исключениями

int main() {
    setlocale(LC_ALL, "Russian");
    srand(static_cast<unsigned int>(time(0)));

    std::cout << "Генерация 5 случайных чисел от 1 до 100:\n" << std::endl;

    // Запуск замера времени с помощью clock()
    clock_t start_clock = clock();

    // Запуск замера времени с помощью time()
    time_t start_time;
    time(&start_time);

    try {
        for (int i = 1; i <= 5; i++) {
            int randomNumber = rand() % 100 + 1; // Генерация исключения, если число равно 77
            if (randomNumber == 77) {
                throw std::runtime_error("Выпало запрещенное число 77!");
            }
            // Вывод результата в консоль
            std::cout << "Число №" << i << ": " << randomNumber << std::endl;
        }
    }
    catch (const std::exception& e) {
        // Обработка исключения
        std::cout << "\nПерехвачено исключение: " << e.what() << std::endl;
    }

    // Остановка замеров времени
    clock_t end_clock = clock();

    time_t end_time;
    time(&end_time);

    // Расчет затраченного времени
    double seconds_clock = static_cast<double>(end_clock - start_clock) / CLOCKS_PER_SEC;
    double seconds_time = difftime(end_time, start_time);

    // Вывод результатов измерения
    std::cout << "\n--- Замеры времени ---" << std::endl;
    std::cout << "Время через clock(): " << seconds_clock << " секунд" << std::endl;
    std::cout << "Время через time():  " << seconds_time << " секунд" << std::endl;

    return 0;
}