
# MainWindow

Slouží k nastavení obtížnosti a vytvoření gridu


# HiddenCode
Vyvtvoření tajného kódu, který je potřeba uhodnout. Čísla v tajném kódu se nemohou opakovat.


# Box.xaml
Vytvoření čtverečků, který mění barvy

# Box.cs
ColorIndex slouží ke změně barvy a k porovnávání s HiddenCodem. YIndex slouží ke kontrole, aby se hráč mohl pohybovat jen v jednom řádku

# EndScreen.xaml
Okno, které se otevře po skončení hry

# Game
Hlavní funkčnost a logika hry. 

## CreateResultSquares()
Vytváří pravou stranu obrazovky, kde se ukazují výsledky.

## Check() 
Projde všechny potomky hrací plochy, pokud najde Box, který má stejné souřadnice jako Box, na který hráč kliknul, tak nastaví do GuessedCode hodnotu ColorIndexu.

## CheckIfFilled() 
Kontroluje, zda byly všechny čtverečky vyplněné. Pokud ano, metoda Check pokračuje, pokud ne, metoda končí a nic se neděje.

## ChangeResultColors()
Projde všechny potomky _results, pokud najde Rectangle, tak zkontroluje porovná souřadnice Boxu a Výsledku a přebarví výsledky.



