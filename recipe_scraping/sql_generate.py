import json

def write_json_to_file(title,stuff):
    with open(title+".json", 'w') as f:
        f.write(json.dumps(stuff,indent=4))


def read_json_from_file(file) -> dict:
    with open(file,'r') as f:
        stuff=f.read()
        otherstuff=json.loads(stuff)
        return otherstuff
    return None

import glob
from get_single_json import join_lists


#
liszt=[ read_json_from_file(f) for f in glob.glob("recipes/*.json") ]

just_ingredients = set(join_lists([liszt2["just_ingredients"] for liszt2 in liszt]))
import uuid

def get_id():
    return f"CAST('{str(uuid.uuid4())}' AS UNIQUEIDENTIFIER)"

just_ingredients_dict = { i: get_id() for i in just_ingredients }

ingredients = set(join_lists([liszt2["ingredients"] for liszt2 in liszt]))

def base_ingredient_id_from_ingredient(name): # "1 pound of garlic" -> "garlic"
    for i in just_ingredients:
        if i in name:
            return just_ingredients_dict[i]

ingredients_dict = { 
    i: {
        "Id": get_id(),
        "Name": i,
        "BaseIngredientId": base_ingredient_id_from_ingredient(i),
    }for i in ingredients 
}

recipes = []
recipeIngredients = []

def remove_duplicates(liszt):
    res = []
    for i in liszt:
        if i not in res:
            res.append(i)
    return res

for r in liszt:
    thing = {
        "Id": get_id(),
        "TimeMinutes": r["total time"],
        "Name": r["title"],

        "Instructions": r["instructions"],
        "Image": r["image"],
    }
    recipes.append(thing)
    for i in remove_duplicates(r["ingredients"]):
        recipeIngredients.append({
            "RecipeId": thing["Id"],
            "IngredientId": ingredients_dict[i]["Id"],
        })


def escape_quotes(thing):
    return thing.replace("'", "''")

def print_recipe_sql(entry, f):
    print(f"""INSERT INTO [dbo].[Recipes]
           ([Id]
           ,[Name]
           ,[TimeMinutes]
           ,[Instructions]
           ,[Image])
     VALUES
           ({entry["Id"]}
           ,N'{escape_quotes(entry["Name"])}'
           ,'{entry["TimeMinutes"]}'
           ,N'{escape_quotes(entry["Instructions"])}'
           ,N'{escape_quotes(entry["Image"])}')
    GO""", file=f)

def print_ingredients_sql(entry, f):
    print(f"""
        INSERT INTO [dbo].[Ingredients]
           ([Id]
           ,[BaseIngredient_ID]
           ,[FullName])
     VALUES
           ({entry["Id"]}
           ,{entry["BaseIngredientId"]}
           ,N'{escape_quotes(entry["Name"])}')
    GO
        """, file =f)


def print_base_ingredients_sql(id, name, f):
    print(f"""
    INSERT INTO [dbo].[BaseIngredients]
           ([Id]
           ,[Name])
     VALUES
           ({id}
           ,N'{escape_quotes(name)}')
    GO
    """, file=f)

def print_recipe_ingredients_sql(entry, f):
    print(f"""
    INSERT INTO [dbo].[RecipeIngredients]
           ([RecipeId]
           ,[IngredientId])
     VALUES
           ({entry["RecipeId"]}
           ,{entry["IngredientId"]})
GO
    """, file=f)

with open("thing.sql", 'w') as the_file:
    for entry in recipes:
        print_recipe_sql(entry, the_file)

    for name, id in just_ingredients_dict.items():
        print_base_ingredients_sql(id, name, the_file)

    for entry in ingredients_dict.values():
        print_ingredients_sql(entry, the_file)

    for entry in recipeIngredients:
        print_recipe_ingredients_sql(entry, the_file)
