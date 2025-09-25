# GroceryApp sprint3 Studentversie  
    
## UC07 Delen boodschappenlijst  
Is compleet  
  
## UC08 Zoeken producten  
Aanvullen:
- In de GroceryListItemsView zitten twee Collection Views, namelijk één voor de inhoud van de boodschappenlijst en één voor producten die je toe kunt voegen aan de boodschappenlijst  
- Voeg boven de tweede CollectionView een zoekveld (SearchBar) in om op producten te kunnen zoeken.  
- Zorg dat de SearchCommand wordt gebonden aan een functie in het onderliggende ViewModel (GroceryListItemsViewModel) en dat de zoekterm die in het zoekveld is ingetypt gebruikt wordt als parameter (SearchCommandParameter).  
- Werk in het viewModel (GroceryListItemsViewModel) de zoekfunctie uit en zorg dat de beschikbare producten worden gefilterd op de zoekterm!  

## UCx Registratie gebruiker 
Aanvullen:

- Voeg een knop toe in de LoginView waarmee een gebruiker een nieuw account kan aanmaken.
- Zorg dat de knop gebonden is aan een CreateCommand in het onderliggende ViewModel (LoginViewModel).
- Controleer in het ViewModel of het ingevoerde e-mailadres nog niet bestaat in de lijst met clients.
- Voeg validatie toe zodat alle verplichte velden (e-mail en wachtwoord) ingevuld moeten zijn.
- Toon meldingen in de UI als het e-mailadres al in gebruik is of als velden ontbreken.
- Maak in het ViewModel een nieuwe client aan met e-mailadres en wachtwoord (gehashed via PasswordHelper).
- Stel na succesvol aanmaken de ingelogde gebruiker in en navigeer automatisch naar de AppShell.
