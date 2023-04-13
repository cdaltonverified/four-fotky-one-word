### import Module
from bs4 import BeautifulSoup
from pathlib import Path
import requests
import os

### Download image Per Keyword 
img_download_count = 4

### Image keywords
keys = ["brainstorm", "blueprint", "turkey", "groundhog", "cheetah", "knee", "inertia", "tribe", "president", "champion", "opaque", "sapphire", "promise", "digestion", "population", "riddle", "Zen", "rival", "error", "tutor", "navigate", "wetlands", "forklift", "pelt", "writhe", "form", "dugout", "panic", "improve", "wormhole", "blunt", "courthouse", "wealth", "rhyme", "statement", "neutron", "dud", "admire", "companion", "quiver", "danger", "interference", "ligament", "altitude", "observatory", "chord", "treatment", "drift", "shame", "cartography"]

### Image saving folder Create
def save_image(key):
    image_folder = Path.cwd()
    image_folder = f"{str(image_folder)}/Image/{key}/"
    if not os.path.exists(image_folder):
        os.makedirs(image_folder)
    return image_folder


### Image searching and collect all images Url
def img_name(key):
    ### Image url List
    image_list = []
    url = f"https://www.bing.com/images/search?q={key}" # search URL for image results
    print(url)

    response = requests.get(url)
    for _ in range(6):
        soup = BeautifulSoup(response.content, "html.parser")
        response = requests.get(url, headers={"Range": "bytes=100-"})
        results = soup.find_all("div", class_="imgpt")
        
    for x in range(img_download_count):
        img_url = results[x].find("img")["src"]
        image_list.append(img_url)
        
    return image_list

### Image downloading 
def download_image(list_image, key):
    i=0
    for image_url in list_image:
        page = requests.get(image_url)
### Image file name Create
        filename = image_url.split("/")[-1]
        filename = filename.replace(".", "-").replace("?", "-").replace("=", "-")
        full_filename = save_image(key) + filename+ ".jpg"

### Image name create and save image        
        with open(full_filename, 'wb') as f:
            f.write(page.content)
            #print(full_filename)
    return "Collection Success"

### Loop for Image Keywords
for key in keys:
    try:
        list_image = img_name(key)
        download_image(list_image,key)
    except:
        try:
            list_image = img_name(key)
            download_image(list_image, key)
        except:
            pass

    print("Collection Done.... >>> " , key)
    
print(" ------ Collection End  ------")