from get_all_jsons import write_recipe_to_file, write_json_to_file

s ="https://www.allrecipes.com/recipes/715/world-cuisine/european/eastern-european/polish/"

import recipe_scrapers


links_zwo_drei = recipe_scrapers.scrape_me(s).links()

import re



write_recipe_to_file("https://www.tasteatlas.com/ciorba-de-legume")

links = set(filter(lambda hr: re.match(r"https://www.allrecipes.com/recipe/", hr),
     map(lambda x: x["href"], links_zwo_drei)))


for l in links:
    print(l)
    write_recipe_to_file(l)
