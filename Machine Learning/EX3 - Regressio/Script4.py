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

# Dataset (mateix que script 3 + nova variable)
df = pd.DataFrame({
    "superficie": [80, 80, 100, 100],
    "zona": ["Normal", "Bona", "Normal", "Bona"],
    "any": [1965, 2005, 1965, 2005],
    "numero_porta": [12, 87, 34, 56],  # variable inútil però plausible
    "preu": [170000, 220000, 210000, 280000]
})

# Conversió zona
df["zona_num"] = zonaNumericaSerie(df["zona"])

X = df[["superficie", "zona_num", "any", "numero_porta"]]
y = df["preu"]

model = LinearRegression()
model.fit(X, y)

# Predicció
test = pd.DataFrame({
    "superficie": [80],
    "zona_num": [1],
    "any": [2005],
    "numero_porta": [50]
})

pred = model.predict(test)[0]
preu_real = 220000
error = abs(preu_real - pred)

print("Predicció:", int(pred))
print("Preu real:", preu_real)
print("Error:", int(error))
