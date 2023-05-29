# MarkoPolo
**ZADANIE TESTOWE PROGRAMISTA C#**

Część I:
Stworzyć fragment gry ("symulacji"):
Na start stworzyć kilku agentów (min. 3 max. 5, kontrolowane z inspektora)Losowo z zakresu od 2 do 6 sekund (kontrolowanych z inspektora) generować nowego agenta
Maksymalnie powinno być nie więcej niż 30 agentów na raz (ustawienie również kontrolowane z inspektora)
Agenci poruszają się na ograniczonej planszy (np. 10x10, kontrolowane z inspektora, 
pathfinding nie wymagany) z prędkością również kontrolowaną z poziomu inspektora
Jeżeli 2 agentów zetknie się ze sobą tracą po 1 punkcie życia (ze startowych 3)
Jako gracze, możemy kliknąć na agenta (zaznaczyć go)
na UI pojawia się jego nazwa i ilość HP - proste UI typu overlay, które powinno skalować się do różnych rozdzielczości ekranu
możemy również odznaczyć agenta
dobrze aby sam agent też miał jakąś formę zaznaczenia na sobie
Proszę założyć lokalne repozytorium GIT i commitować częściowe rozwiązania (min. ok. 10 commitów aby można było podejrzeć proces tworzenia rozwiązania)

Część II:
Dodatkowo po naciśnięciu przycisku na UI (na tej samej scenie co część I), w okienku tekstowym proszę wypisać:
Kolejno, w nowych liniach, liczby od 1 do 100 w następujący sposób:
jeżeli liczba jest podzielna przez trzy wypisać "Marko"
jeżeli jest podzielna przez pięć wypisać "Polo"
jednak jeżeli równocześnie podzielna przez trzy i pięć wypisać "MarkoPolo"
w każdym innym przypadku wypisać samą liczbę

Proszę użyć Unity 2022.2.19f1

Oceniane będą:
Zrozumienie zagadnień (przedstawionych problemów do rozwiązania)
Poprawność działania (np. brak błędów)
Organizacja kodu: jak komunikują się moduły, jak kod jest podzielony i zorganizowany, czy architektura jest dopasowana do wielkości projektu (a jednocześnie pozwala na jego łatwy dalszy rozwój)
Czystość kodu i projektu: nazwy, jak łatwo się go czyta (co niekoniecznie oznacza komentarze!), jak łatwo dałoby się go zmodyfikować, wiadomości w commitach, itp.
Znajomość Unity i C#
Podejście do rozwiązań
Elementy i detale wykraczające poza min. zadania
Grafika może być jedynie symboliczna
Jakiekolwiek dodatkowe elementy (wizualne i inne) będą brane na plus
Jednak najwyżej będzie brany pod uwagę nadal kod!
