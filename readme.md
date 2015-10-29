Windows Phone MonsterHunter4UDatabase
=====================================

A port of the Android MH4U Data app for Windows Phone.

Android: https://github.com/kamegami13/MonsterHunter4UDatabase
iOS: https://github.com/nshetty26/MH4UDatabase

### Building

Build App using Visual Studio 2015

### Database

Uses the same sqlite3 database as the android project, but was modified slightly so that armor and weapon items have their icon populate.

### Project Layout

**Database**
  - Contains classes for data objects
  - Contains database queries

**Controls**
  - Contains custom controls

**Converters**
  - Contains IValueConverters for XAML binding

**TemplateSelectors**
  - Contains template selectors for item collections

**Pages**
  - Contains the page XAML

**ViewModel**
  - Contains the ViewModels for each page
