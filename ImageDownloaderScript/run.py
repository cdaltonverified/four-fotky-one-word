### import Module
from bs4 import BeautifulSoup
from pathlib import Path
import requests
import re
import os

### Download image Per Keyword 
img_download_count = 4

### Image keywords
keys = ["dog","facebook", "new york", "cat"]

### Image saving folder Create
def save_image(key):
    image_folder = Path.cwd()
    image_folder = f"{str(image_folder)}/Image/{key}/"
    if not os.path.exists(image_folder):
        os.makedirs(image_folder)
    return image_folder

### Image searching and collect all images Url
def img_name(key):
    URL = f'https://www.google.com/search?q={key}&tbm=isch'
    headinfo = {
        "Accept": "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8",
        "Accept-Encoding": "gzip, deflate, br",
        "Accept-Language": "en-US,en;q=0.5",
        "Connection": 'keep-alive',
        "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:106.0) Gecko/20100101 Firefox/106.0"
    }

### request for image page
    page = requests.get(URL, headers=headinfo).content
    soup = BeautifulSoup(page, 'html.parser')
    script = soup.findAll('script')
    
### Image url List
    image_list = []
    for x in script:
        img = x.text
        a = re.findall(
            "(((https://www)|(http://)|(www))[-a-zA-Z0-9@:%_\+.~#?&//=]+)\.(jpg|jpeg|gif|png|bmp|tiff|tga|svg)", img)
        for i in a:
            full_url = f"{i[0]}.{i[5]}"
            image_list.append(full_url)
    return image_list

### Image downloading 
def download_image(list_image, key, img_download_count=4):
    count = 1
    for image_url in list_image:
        if count > img_download_count:
            break
        
        if 'http' not in image_url:
            try:
                page = requests.get(f"https://{image_url}")
            except Exception:
                page = requests.get(f"http://{image_url}")
        else:
            page = requests.get(image_url)
            
        if page.status_code != 200:
            continue
        
### Image file name Create
        filename = image_url.split("/")[-1]
        full_filename = save_image(key) + filename

### Image name create and save image        
        with open(full_filename, 'wb') as f:
            f.write(page.content)
        count += 1
        
    return "Collection Success"

### Loop for Image Keywords
for key in keys:
    list_image = img_name(key)
    download_image(list_image,key,img_download_count)
    print("Collection Done.... >>> " , key)
    
print(" ------ Collection End  ------")