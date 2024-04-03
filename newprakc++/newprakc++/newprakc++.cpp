#include <iostream>

class BankAccount {
private:
    int accountNumber;
    double balance;
    double interestRate;

public:
    BankAccount(int accountNumber, double balance) : accountNumber(accountNumber), balance(balance), interestRate(0.0) {}

    void deposit(double amount) {
        if (amount > 0) {
            balance += amount;
        }
        else {
            std::cerr << "Некорректная сумма для внесения." << std::endl;
        }
    }

    bool withdraw(double amount) {
        if (amount > 0 && balance >= amount) {
            balance -= amount;
            return true;
        }
        else {
            std::cerr << "Некорректная сумма для снятия или недостаточно средств на счете." << std::endl;
            return false;
        }
    }

    double getBalance() const {
        return balance;
    }

    double getInterest() const {
        return balance * interestRate * (1.0 / 12.0);
    }

    void setInterestRate(double rate) {
        if (rate >= 0) {
            interestRate = rate;
        }
        else {
            std::cerr << "Некорректная процентная ставка." << std::endl;
        }
    }

    int getAccountNumber() const {
        return accountNumber;
    }

    // Дружественная функция для перевода средств между счетами
    friend bool transfer(BankAccount& from, BankAccount& to, double amount);
};

bool transfer(BankAccount& from, BankAccount& to, double amount) {
    if (from.withdraw(amount)) {
        to.deposit(amount);
        return true;
    }
    return false;
}

// Пример использования
int main() {
    setlocale(LC_ALL, "RUS");
    BankAccount account1(12345, 1000.0);
    BankAccount account2(67890, 500.0);

    account1.setInterestRate(0.05); // Установка процентной ставки 
    account2.setInterestRate(0.03); 

    std::cout << "Стартовый баланс account1: " << account1.getBalance() << std::endl;
    std::cout << "Стартовый баланс account2: " << account2.getBalance() << std::endl;

    account1.deposit(500.0); // Внесение 
    account2.withdraw(200.0); // Снятие 

    std::cout << "Текущий баланс account1: " << account1.getBalance() << std::endl;
    std::cout << "Текущий баланс account2: " << account2.getBalance() << std::endl;

    transfer(account1, account2, 300.0); // Перевод средств

    std::cout << "Текущий баланс account1: " << account1.getBalance() << std::endl;
    std::cout << "Текущий баланс account2: " << account2.getBalance() << std::endl;

    return 0;
}