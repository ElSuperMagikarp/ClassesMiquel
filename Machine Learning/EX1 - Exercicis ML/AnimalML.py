import argparse
from sklearn.tree import DecisionTreeClassifier

# --- Dades d'entrenament ---
# Característiques: [Si te pel (0=False, 1=True), pes en kg]
X = [[1, 6], [1, 7], [1, 7.9], [1, 8], [1, 200],
    [0, 0.1], [0, 0.9], [0, 1], [0, 1.6], [0, 200]]
y = ["Gat", "Gat", "Gat", "Gos", "Gos",
     "Ocell", "Ocell", "Gallina", "Gallina", "Gallina"]

model = DecisionTreeClassifier()
model.fit(X, y)

# --- Arguments per consola ---
parser = argparse.ArgumentParser(description="Classificador de animals amb ML")
parser.add_argument("pel", type=int, help="Si l'animal te pel o no (0 = False, 1 = True)")
parser.add_argument("pes", type=float, help="Pes del animal en kgs")
args = parser.parse_args()

# --- Predicció ---
prediccio = model.predict([[args.pel, args.pes]])
print(f"Predicció: {prediccio[0]}")