import numpy as np
from sklearn.linear_model import LinearRegression
from sklearn.metrics import mean_absolute_error

# Dataset
X = np.array([[50], [70], [90], [110]])
y = np.array([120000, 160000, 210000, 260000])

# Model
model = LinearRegression()
model.fit(X, y)

# Predicció
superficie = np.array([[80]])
pred = model.predict(superficie)[0]

# Error
preu_real = 220000  # L'immoble està en una zona bona => preu més elevat. 

error = abs(preu_real - pred)

print("Predicció:", int(pred))
print("Preu real:", preu_real)
print("Error:", int(error))