# EXERCICIS REGRESSIÓ

## Script 1

### 1. Després de mirar el script, quin model s'està utilitzant?  
Un model de regressió lineal, com s'indica a la línea 10: `model = LinearRegression()`

### 2. Per quin motiu l'error és tan elevat?  
Perque falten dades. No coneix la zona dels pisos el qual fa variar molt el preu

### 3. Com es pot millorar la precisió de la predicció?  
Donant-li l'informació de la zona en que es situa el pis

---

## Script 2

### 1. Per quin motiu l’error ha disminuït respecte a l’script 1?  
Perque ara el model coneix la zona dels pisos. Aquests context adicional li deixa predir millor el preu

---

## Script 3

### 1. Quins factors fan que, en aquest dataset, afegir l’any de construcció tingui un impacte limitat en l’error del model?  
Perque totes les zones del 2005 són bones i totes les zones del 1965 són normals.  
El model no té exemples de pisos nous a zones normals o pisos vells a zones bones, per tant es pot dir que te en compte l'any de la mateixa manera que la zona.
Per solucionar-ho s'hauria de posar més dades amb més casos

---

## Script 4

### 1. L’error ha augmentat després d’afegir una nova variable. Per quin motiu?  
Perqué la dada nova que s'ha introduit (El numero de porta) es completament irrellevant pel preu del pis.
A més, hi han tan poques dades de training que el algorisme és incapaç de reconeixer que el número de porta no afecta al preu, per tant està intentant buscar i reproduir un patró que no existeix.

---

## Script 5

### 1. Modifica el codi del script 3 per millorar la predicció actuant sobre les dades utilitzades pel model (sense canviar l’algoritme).  

---