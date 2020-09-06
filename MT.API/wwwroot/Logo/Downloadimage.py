import re
import requests
from bs4 import BeautifulSoup
import os

path = 'C:/Users/Akram/Desktop/Python/LogoImage'

site = 'https://www.carlogos.org/other-countries-car-brands/'

response = requests.get(site)

soup = BeautifulSoup(response.text, 'html.parser')
img_tags = soup.find_all('img')

urls = [img['src'] for img in img_tags]


for url in urls:
   #  url.replace('/european-car-brands/','')
    filename = re.search(r'/([\w_-]+[.](png))$', url)
    if not filename:
         print("Regex didn't match with the url: {}".format(url))
         continue
    with open(filename.group(1), 'wb') as f:
        if 'http' not in url:
            # sometimes an image source can be relative 
            # if it is provide the base url which also happens 
            # to be the site variable atm. 
            url = '{}{}'.format(site, url)
            newurl = url.replace('/other-countries-car-brands/', '')
            #'https://www.carlogos.org/european-car-brands//car-logos/porsche-logo.png'
           
        response = requests.get(newurl)
        f.write(response.content)

