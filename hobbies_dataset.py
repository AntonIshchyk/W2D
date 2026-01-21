import pandas as pd

df = pd.read_csv("hf://datasets/alperugurcan/Hobbies/hobbies.csv")

print(f"Loaded {len(df)} hobbies")

# Convert to JSON and save
output_file = "hobbies_dataset.json"
df.to_json(output_file, orient='records', indent=2)

print(f"\n✓ Saved dataset to {output_file}")