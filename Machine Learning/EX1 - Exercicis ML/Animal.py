import argparse

def classifica_animal(pel, pes):
    if pel == 1 and pes < 8:
        return "Gat"
    elif pel == 1 and pes >= 8:
        return "Gos"
    elif pes < 1:
        return "Ocell"
    else:
        return "Gallina"

parser = argparse.ArgumentParser("")

parser.add_argument("pel", help="Si l'animal te pel o no (0 = False, 1 = True)", type=int)
parser.add_argument("pes", help="Pes del animal en kgs", type=float)

args = parser.parse_args()

pel = args.pel
pes = args.pes

print("Pel: ",classifica_animal(pel,pes))