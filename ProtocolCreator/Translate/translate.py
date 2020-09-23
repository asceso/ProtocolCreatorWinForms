from googletrans import Translator
import os
curentDir = os.getcwd()
translator = Translator()
print('read input')
with open(curentDir + '\\Translate\\words_input.txt', 'r', encoding='UTF8') as file:
    buffer = file.read()
print('translate words')
words = buffer.split()
engwords = list()
for word in words:
    engwords.append(translator.translate(word, dest='en', src='ru').text)
print('write output')
with open(curentDir + '\\Translate\\words_output.txt', 'w', encoding='UTF8') as file:
    for word in engwords:
        file.write(word)
        file.write(' ')