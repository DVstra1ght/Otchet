#include "pch.h"     
#include "CppUnitTest.h"
#include <iostream>    
#include <stdexcept> 

struct UnitConverter {
 
    static double celsiusToFahrenheit(double celsius) {
        if (celsius < -273.15) {
            throw std::invalid_argument("Температура ниже абсолютного нуля (-273.15 C)");
        }
        return (celsius * 9.0 / 5.0) + 32.0;
    }

   
    static double fahrenheitToCelsius(double fahrenheit) {
        if (fahrenheit < -459.67) {
            throw std::invalid_argument("Температура ниже абсолютного нуля (-459.67 F)");
        }
        return (fahrenheit - 32.0) * 5.0 / 9.0;
    }

   
    static double metersToFeet(double meters) {
        if (meters < 0.0) {
            throw std::invalid_argument("Длина в метрах не может быть отрицательной");
        }
        return meters * 3.28084;
    }


    static double feetToMeters(double feet) {
        if (feet < 0.0) {
            throw std::invalid_argument("Длина в футах не может быть отрицательной");
        }
        return feet * 0.3048;
    }
};

int main() {
    setlocale(LC_ALL, "Russian");

    try {
        std::cout << "0 C в Фаренгейтах: " << UnitConverter::celsiusToFahrenheit(0) << " F" << std::endl;
        std::cout << "100 метров в футах: " << UnitConverter::metersToFeet(100) << " ft" << std::endl;

      
    }
    catch (const std::invalid_argument& e) {
        std::cerr << "Ошибка: " << e.what() << std::endl;
    }

    return 0;
}



