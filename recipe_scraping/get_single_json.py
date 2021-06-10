
def write_json_to_file(title,stuff):
    import json
    with open(title+".json", 'w') as f:
        f.write(json.dumps(stuff,indent=4))

def join_lists(big_list):
    #print("og:",big_list)
    liszt=[]
    for l in big_list:
        # print("l:",l)

        liszt+=l
    return liszt
def unique(og): 
    a = list(set(og))
    a.sort()
    return a
def write_recipe_to_file(link):
    from recipe_scrapers import scrape_me
    scraper = scrape_me(link, wild_mode=True)

    # and we should somehow do smth like this:
    # but with our data
    ingredients = scraper.ingredients()
    write_json_to_file("recipes/"+scraper.title(), {
        #zis is a dictionary
        # dictionary go brrrrrrrrrrr
        "title": scraper.title(), 
        "ingredients": ingredients,
        "just_ingredients": unique(join_lists([ extract_ingredient(i) for i in ingredients ])),
        "image": scraper.image(),
        "instructions": scraper.instructions(),
        "total time":scraper.total_time(),
        "yields:":scraper.yields()})

import re
def remove_leading_number(name):
    if match := re.match(r"^(\d+)\s*(.*)", name):
        name = match.group(2)
    if match := re.match(r"^[↉⅐⅑⅒⅓⅔⅕⅖⅗⅘⅙⅚⅛⅜⅝⅞⅟½⅓¼⅛¾⅔⅕⅖⅗] (.*)", name):
        name = match.group(1)

    return name
def remove_parens(name):
    # (stuff) more (sthfutff )
    if match := re.match(r"\((.*?)\) (.*)", name):
        return match.group(2)
    return name
def remove_unit(name):
    units = ["carton", "cube", "pound", "teaspoon", "bunch", "pinch", "spoon",
             "gallon", "ounce", "quart", "cup","milliliter","liter","kilogram",
             "whole", "fluid ounce","can", "container", "tablespoon", "slices",
             "jar", "package", "dash", "bag", "bottle", "can or bottle", "stalk"]
    for u in units:
        if match := re.match(rf"{u}(e?s)? (.*)", name):
            return match.group(2)
    return name
adjs = ["ripe", "pitted", "ground", "sliced", "chopped", "fresh", "finely", "crushed",
        "warm", "hot", "cold", "drained", "rinsed", "shredded", "diced", "cubed", "whole", "peeled"
         "dry","plain","uncooked", "large", "unsalted", "unflavored", "lukewarm", "firm", "cloves"]
def remove_adjective(name):
    for a in adjs:
        if match := re.match(rf"{a} (.*)", name):
            return match.group(1)
    return name

def depluralise(name):
    weirdOnes = {
        "tomatoes": "tomato",
        "apples": "apple",
        "berries": "berries",
        "raisins": "raisins",
        "chives": "chives",

        #"potatoes": "potato"
    }
    if name in weirdOnes:
        return weirdOnes[name]

    return name.removesuffix("s")

def remove_dumb_thing(name):
    dumbThings = [
        "to taste", "- peeled","- rinsed and drained"
    ]
    for d in dumbThings:
        name = name.removesuffix(d)
    for a in adjs:
        name = name.removesuffix("- "+a)
    if match := re.match(rf"(.* )\(.*", name):
        return match.group(1)
    return name


def extract_ingredient(name):
    #if "thing" in name: # name.contains("thing") -> 
    #ie "2 carrots, grated" => carrots

    dumber_things = ["chicken breast", "corned beef", "potatoes"]

    for dt in dumber_things:
        if dt in name:
            #print("returnink", dt)
            return [dt]

    thing = name.split(',')[0]
    thing = thing.strip()
    thing = remove_leading_number(thing)
    thing = remove_parens(thing)

    #print(f"t1: {thing}")
    thing = remove_unit(thing)
    thing = remove_adjective(thing)
    thing = remove_adjective(thing)


    thing = remove_dumb_thing(thing)
    thing = remove_dumb_thing(thing)

    #print(f"t2: {thing}")


    thing = depluralise(thing)

    #print(f"t3: {thing}")

    thing = thing.strip()

    #print(f"t4: {thing}")


    if thing in ["salt and pepper", "salt and ground black pepper"]:
        return ["salt", "peper"]
        
    return [thing]
    

# baked chicken reuben breast half
#large head, uncooked, dried, fresh 
#beaten - Mazurek (Polish easter cake)
#sliced- Reuben Casserole
#
#for ing in ["\u00bd onion, finely chopped",
#            "1 red onion, chopped",
#            "\u00bd (8 ounce) carton sour cream",
#            "2 eggs",
#            "1 teaspoon garlic and herb seasoning blend (such as Mrs. Dash\u00ae)",
#            "1 pound dry navy beans, rinsed and picked through",
#            "1 ½ cups water, divided",
#            "6 ounces salt pork, diced",
#            "salt and ground black pepper to taste",
#            "1 pinch dried dill weed",
#            "1 clove garlic, pressed",
#            "extra virgin olive oil",
#            "2 (14.5 ounce) cans chicken broth",
#            "1 cube chicken bouillon",
#            "½ bunch fresh cilantro, chopped",
#            "2 gallons water",
#            "5 pounds chicken leg quarters",
#            "⅓ cup sour cream",
#            "¼ cup all-purpose flour",
#            "⅛ teaspoon salt"]:
#    print("'%s' -> '%s'" % (extract_ingredient(ing), ing) )
#


