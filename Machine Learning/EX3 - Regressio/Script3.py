import pandas as pd
from sklearn.linear_model import LinearRegression

def zonaNumericaSerie(zona_series):
    return zona_series.map({
        "Normal": 0,
        "Bona": 1
    })

def zonaNumericaValor(zona):
    return {
        "Normal": 0,
        "Bona": 1
    }[zona]

# Dataset
df = pd.DataFrame({
    "superficie": [80, 80, 100, 100],
    "zona": ["Normal", "Bona", "Normal", "Bona"],
    "any": [1965, 2005, 1965, 2005],
    "preu": [170000, 230000, 210000, 280000]
})

# Conversió zona
df["zona_num"] = zonaNumericaSerie(df["zona"])

# Variables
X = df[["superficie", "zona_num", "any"]]
y = df["preu"]

# Model
model = LinearRegression()
model.fit(X, y)

# Predicció
superficie = 80
zona = "Bona"
any_construccio = 2005

zona_num = zonaNumericaValor(zona)

test = pd.DataFrame({
    "superficie": [superficie],
    "zona_num": [zona_num],
    "any": [any_construccio]
})

pred = model.predict(test)[0]
preu_real = 220000
error = abs(preu_real - pred)

print("Predicció:", int(pred))
print("Preu real:", preu_real)
print("Error:", int(error))
