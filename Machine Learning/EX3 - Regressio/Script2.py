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
    "preu": [170000, 230000, 210000, 280000]
})

# Model
df["zona_num"] = zonaNumericaSerie(df["zona"])

X = df[["superficie", "zona_num"]]
y = df["preu"]

model = LinearRegression()
model.fit(X, y)

# Predicció
superficie = 80
zona = "Bona"
zona_num = zonaNumericaValor(zona)

test = pd.DataFrame({
    "superficie": [superficie],
    "zona_num": [zona_num]
})

pred = model.predict(test)[0]
preu_real = 220000

error = abs(preu_real - pred)

print("Predicció:", int(pred))
print("Preu real:", preu_real)
print("Error:", int(error))