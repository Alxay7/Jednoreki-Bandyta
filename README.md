# 🎰 Jednoreki Bandyta

<div align="center">

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-12-239120?style=for-the-badge&logo=csharp&logoColor=white)
![WPF](https://img.shields.io/badge/WPF-Windows-0078D4?style=for-the-badge&logo=windows&logoColor=white)
![Platform](https://img.shields.io/badge/Platform-Windows-0078D4?style=for-the-badge&logo=windows&logoColor=white)

**Klasyczna gra na automatach w stylu kasynowym, zbudowana w C# z WPF.**

</div>

---

## 📖 Opis

**Jednoreki Bandyta** to desktopowa gra symulująca klasyczny automat kasynowy (slot machine). Trzy bębny z sześcioma różnymi symbolami kręcą się przy każdym obróceniu, a wypłaty zależą od ułożonych kombinacji. Możesz ustawić własny mnożnik zakładu i obserwować, jak Twój portfel rośnie (lub topnieje)!

---

## 🎮 Funkcje

- 🎲 **3 bębny × 3 rzędy** – 9 widocznych symboli na raz
- 💰 **Dynamiczne wypłaty** – im rzadsza kombinacja, tym wyższy mnożnik wygranej
- ⚙️ **Konfigurowalny mnożnik zakładu** – dostosuj stawkę do swoich preferencji
- 🎬 **Animowane bębny** – regulowana długość i prędkość animacji
- 🪙 **Wizualizacja żetonów** – saldo wyświetlane jako stosy żetonów kasynowych
- 🏦 **Startowe saldo: $1 000**

---

## 🃏 Symbole i wypłaty

| Symbol | Opis |
|--------|------|
| 🍒 1 | Wiśnia (Cherry) |
| 🍇 2 | Winogrona (Grapes) |
| 7️⃣ 3 | Siódemka (Seven) |
| 🔔 4 | Dzwonek (Bell) |
| 🎰 5 | Single BAR |
| 🎰 6 | Multi BAR |

### 💵 Tabela wypłat (× mnożnik × $5)

| Kombinacja | Wypłata |
|-----------|---------|
| 🍒🍒🍒 Trzy wiśnie lub 🔔🔔🔔 Trzy dzwonki | **300×** |
| 🍒🔔🔔 Wiśnia + dwa dzwonki lub 🎰🎰🎰 Trzy Multi BAR | **60×** |
| 🍒🍒🔔 Dwie wiśnie + dzwonek lub 🎰🎰🎰 Trzy Single BAR | **30×** |
| 🍇🍇🍇 Trzy winogrona lub 🍒 + 🔔 (dowolna pozycja) | **20×** |
| Dowolne dwie wiśnie lub wszystkie trzy BAR (mix 5 i 6) | **15×** |
| Dowolna jedna wiśnia | **6×** |
| 7️⃣7️⃣7️⃣ Trzy siódemki | **10 000×** 🏆 |

> Koszt obrotu: **$5 × mnożnik**

---

## 🚀 Uruchomienie

### Wymagania

- Windows 10/11
- [.NET 8.0 Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) (lub Visual Studio 2022+)

### Uruchomienie z Visual Studio

1. Sklonuj repozytorium:
   ```bash
   git clone https://github.com/Alxay7/Jednoreki-Bandyta.git
   ```
2. Otwórz plik `Jednoreki Bandyta.sln` w Visual Studio 2022+
3. Naciśnij **F5** lub **Ctrl+F5**, aby uruchomić grę

### Uruchomienie z wiersza poleceń

```bash
# Budowanie
dotnet build "Jednoreki Bandyta/Jednoreki Bandyta.csproj"

# Uruchomienie
dotnet run --project "Jednoreki Bandyta/Jednoreki Bandyta.csproj"
```

---

## 🕹️ Jak grać

1. **Ustaw mnożnik** – wpisz wartość w polu "Multiplayer" (domyślnie 1)
2. **Kliknij Spin** – bębny zaczną się kręcić, a $5 × mnożnik zostanie odjęte z salda
3. **Obserwuj animację** – symbole losowo się zmieniają przez ustawiony czas
4. **Sprawdź wygraną** – po zatrzymaniu bębnów, wygrana zostaje dodana do portfela
5. **Dostosuj animację** – suwaki pozwalają zmienić długość (5–200 klatek) i prędkość (50–500 ms) animacji

---

## 🗂️ Struktura projektu

```
Jednoreki-Bandyta/
├── Jednoreki Bandyta/
│   ├── Resources/
│   │   ├── backgrounds/    # Tła stołu (niebieski, zielony, czerwony)
│   │   ├── chips/          # Wizualizacje stosów żetonów
│   │   └── slots/          # Symbole bębnów i grafiki maszyny
│   ├── MainWindow.xaml     # Układ interfejsu użytkownika
│   ├── MainWindow.xaml.cs  # Logika gry
│   └── App.xaml            # Punkt wejścia aplikacji
└── Jednoreki Bandyta.sln   # Plik rozwiązania Visual Studio
```

---

## 🛠️ Technologie

| Technologia | Opis |
|-------------|------|
| **C# 12** | Język programowania |
| **.NET 8.0** | Platforma uruchomieniowa |
| **WPF** | Windows Presentation Foundation – framework UI |
| **XAML** | Deklaratywny opis interfejsu |
| **async/await** | Animacja bębnów bez blokowania UI |

---

## 📜 Licencja

Projekt dostępny do użytku prywatnego i edukacyjnego.

---

<div align="center">
Zbudowane z ❤️ w C# · <em>Graj odpowiedzialnie! 🎰</em>
</div>
