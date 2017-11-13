import requests
import random
#import json
import xml.etree.cElementTree as ET
from bs4 import BeautifulSoup
from unicodedata import normalize

##Declarações
idInicial = 0
times = []
pages = []
pages.append(["Brasileirao_SerieA.xml", "https://sortitoutsi.net/football-manager-2018/league/102423/brazilian-national-first-division", "Brasileiro - Serie A", "2017-05-07"])
pages.append(["Brasileirao_SerieB.xml", "https://sortitoutsi.net/football-manager-2018/league/107191/brazilian-national-second-division", "Brasileiro - Serie B", "2017-05-07"])
pages.append(["Brasileirao_SerieC.xml", "https://sortitoutsi.net/football-manager-2018/league/107192/brazilian-national-third-division", "Brasileiro - Serie C", "2017-05-07"])
#########################

##Classes
class Jogador(object):
        def __init__(self):
                self.nome = ""
                self.ano = ""
                self.nacionalidade = ""
                self.posicao = ""
                self.power = ""
                self.pot = ""
                self.valor = ""
                self.custo = ""
                self.contrato = ""
                self.academia = False
        def __eq__(self, other): 
                return self.__dict__ == other.__dict__
                

class Time(object):
        def __init__(self):
                self.id = 0
                self.nome = ""
                self.img = ""
                self.sigla = ""
                self.nation = ""
                self.reputacao = ""
                self.dinheiro = ""
                self.jogadores = []
        def __eq__(self, other): 
                return self.sigla == other.sigla
        
def convertJogador(obj):
        if isinstance(obj, Jogador):
                return obj.__dict__
        return obj
##########################
        
        
##Metodos
def getJogador(tr):
        jogador = Jogador()
        infos = tr.find_all('td')
        academy = tr.find_all('span', class_='icon icon-random')
        jogador.nome = infos[1].find('a')['title']
        jogador.ano = infos[2].string.strip(' \t\n\r')
        jogador.nacionalidade = infos[1].find('div', class_='item_info').find('a')['title']
        jogador.posicao = infos[3].string.strip(' \t\n\r')
        jogador.power = infos[8]['value']
        jogador.pot = infos[9]['value']
        jogador.valor = infos[5].string.strip(' \t\n\r').replace('£', '')
        jogador.custo = infos[4].string.strip(' \t\n\r').replace('£', '')
        jogador.contrato = infos[7].string.strip(' \t\n\r')
        if len(academy) > 0:
                jogador.academia = True
        return jogador
        
def getTime( link , nome):
        global idInicial
        time = Time()
        print('=Carregando Time: '+nome)
        pageTeamCRU = requests.get(link)
        pageTeam = BeautifulSoup(pageTeamCRU.content, 'html.parser')
        dd = pageTeam.find('dl', class_='dl-horizontal').find_all('dd')
        
        pageSiglaCRU = requests.get('https://sortitoutsi.net/football-manager-2017/team/'+link.split('/')[-2]+'/'+link.split('/')[-1])
        pageSigla = BeautifulSoup(pageSiglaCRU.content, 'html.parser')
        time.sigla = pageSigla.find_all('span', {'itemprop' : 'title'})[-1].get_text()
        
        time.nome = nome
        time.img = nome.replace(' ', '_')+'.png'
        time.img = time.img.lower()
        time.img = normalize('NFKD', time.img).encode('ASCII','ignore').decode('ASCII')
        time.nation = pageTeam.find('div', class_='panel-body').find_all('img')[0]['alt']
        time.reputacao = dd[3].string.strip(' \t\n\r').replace('£', '')
        time.dinheiro = dd[5].string.strip(' \t\n\r').replace('£', '')
        
        
        #f = open('./TeamIMG/'+time.img, 'wb')
        #f.write(requests.get(pageTeam.find('div', class_='panel-body').find_all('img')[1]['src']).content)
        #f.close()

        
        listJogadoresTD = pageTeam.find_all('tbody')[0].find_all('tr')
        for jogadorTD in listJogadoresTD:
                jogador = getJogador(jogadorTD)
                time.jogadores.append(jogador)
                print('-----Carregado jogador: '+jogador.nome)
        idInicial += 1
        time.id = idInicial
        return time
###########################




##Inicio do Programa
for p in pages:
        times = []
        pageLigaRequest = requests.get(p[1])
        pageLiga = BeautifulSoup(pageLigaRequest.content, 'html.parser')
        listTimesTD = pageLiga.find_all('td', class_='title')

        for timeTD in listTimesTD:
                times.append(getTime(timeTD.find('a')['href'], timeTD.find('a')['title']))
                
                
        #Exportar
        rootXML = ET.Element('PandaFoot')
        CampXML = ET.SubElement(rootXML, 'campeonato')
        ET.SubElement(CampXML, 'nome').text = p[2]
        ET.SubElement(CampXML, 'dataInicio').text = p[3]
        TimesXML = ET.SubElement(CampXML, 'times')
        for t in times:
                timeXML = ET.SubElement(TimesXML, 'time')
                ET.SubElement(timeXML, 'id').text = str(t.id)
                ET.SubElement(timeXML, 'nome').text = t.nome
                ET.SubElement(timeXML, 'img').text = t.img
                ET.SubElement(timeXML, 'sigla').text = t.sigla
                ET.SubElement(timeXML, 'nation').text = t.nation
                ET.SubElement(timeXML, 'reputacao').text = t.reputacao
                ET.SubElement(timeXML, 'dinheiro').text = t.dinheiro
                time_jogadores = ET.SubElement(timeXML, 'jogadores')
                
                for j in t.jogadores:
                        jogadorXML = ET.SubElement(time_jogadores, 'jogador')
                        ET.SubElement(jogadorXML, 'nome').text = j.nome
                        ET.SubElement(jogadorXML, 'ano').text = j.ano
                        ET.SubElement(jogadorXML, 'nacionalidade').text = j.nacionalidade
                        ET.SubElement(jogadorXML, 'posicao').text = j.posicao
                        ET.SubElement(jogadorXML, 'power').text = j.power
                        ET.SubElement(jogadorXML, 'pot').text = j.pot
                        ET.SubElement(jogadorXML, 'valor').text = j.valor
                        ET.SubElement(jogadorXML, 'custo').text = j.custo
                        ET.SubElement(jogadorXML, 'contrato').text = j.contrato
                        if j.academia == True:
                            ET.SubElement(jogadorXML, 'academia')    
                        
        tree = ET.ElementTree(rootXML)
        tree.write("./"+p[0])

##Final do Programa
        
