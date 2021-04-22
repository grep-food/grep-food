# grep-food
This application is about a journal that manages daily recipes for you.  

User {
  Int id;
  Name, Email, password;
  DoneRecipe[] doneRecipes; // "0, 1, 3, 5, 8"
  TodoRecipe[] todoRecipes;
}

Recipe {
  Int id;
  Name;
  Ingredients;
  instructions;
}

DoneRecipe {
  Int id;
  Recipe recipe;
  Int rating; // 5/7
  Image;
  Review;
}
TodoRecipe {
    Int id;
   Recipe recipe;
  Date reminderDate;
}
