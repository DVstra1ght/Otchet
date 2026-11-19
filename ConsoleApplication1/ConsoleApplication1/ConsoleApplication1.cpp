#include "pch.h"
#include "CppUnitTest.h"
#include "..\Имя_Твоего_Проекта\UnitConverter.cpp" // Укажи правильный путь к файлу структуры

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace UnitConverterTests
{
    TEST_CLASS(UnitConverterTestsClass)
    {
    public:
        // --- ПОЗИТИВНЫЕ ТЕСТЫ ---

        // Позитивный тест 1: Проверка перевода градусов Цельсия в Фаренгейты
        TEST_METHOD(TestCelsiusToFahrenheit_ValidValue_ReturnsCorrectValue)
        {
            double celsius = 25.0;
            double expectedFahrenheit = 77.0;

            double result = UnitConverter::celsiusToFahrenheit(celsius);

            Assert::AreEqual(expectedFahrenheit, result, 0.001);
        }

        // Позитивный тест 2: Проверка перевода метров в футы
        TEST_METHOD(TestMetersToFeet_ValidValue_ReturnsCorrectValue)
        {
            double meters = 10.0;
            double expectedFeet = 32.8084;

            double result = UnitConverter::metersToFeet(meters);

            Assert::AreEqual(expectedFeet, result, 0.001);
        }

        // --- НЕГАТИВНЫЕ ТЕСТЫ ---

        // Негативный тест 1: Передача температуры ниже абсолютного нуля
        TEST_METHOD(TestCelsiusToFahrenheit_BelowAbsoluteZero_ThrowsException)
        {
            Assert::ExpectException<std::invalid_argument>(callWithInvalidCelsius);
        }

        // Негативный тест 2: Передача отрицательной длины в метрах
        TEST_METHOD(TestMetersToFeet_NegativeValue_ThrowsException)
        {
            Assert::ExpectException<std::invalid_argument>(callWithNegativeMeters);
        }

    private:
        // Вспомогательные статические функции для негативных тестов
        static void callWithInvalidCelsius()
        {
            UnitConverter::celsiusToFahrenheit(-300.0); // Ниже -273.15
        }

        static void callWithNegativeMeters()
        {
            UnitConverter::metersToFeet(-15.5); // Длина не может быть < 0
        }
    };
}