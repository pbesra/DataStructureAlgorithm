import csv
import webbrowser

class CSV:
    def __init__(self, input_file=None):
        self.row_fields=[]
        self.data=[]
        self.key_value_data=[]
        row_index=0
        with open(input_file, 'r') as file:
            csv_reader = csv.reader(file)
            for item in csv_reader:
                if row_index==0:
                    self.row_fields=item
                    row_index=1
                else:
                    self.data.append(item)
        self.__form_key_value()
    
    def open_urls(self):
        for url in self.data:
            webbrowser.open(url[0])
            

    def __form_key_value(self):
        self.key_value_data=[]
        if self.row_fields is not None and self.data is not None:
            for row in self.data:
                row_map={}
                for i in range(len(row)):
                    row_map[self.row_fields[i]]=row[i]
                self.key_value_data.append(row_map)

        return self.key_value_data
    
    def read_csv(self):
        print(self.key_value_data)
        
    def get_key_value_data(self):
        return self.key_value_data
    
    
csv_object=CSV("src/others/data/urls.csv")
csv_object.open_urls()

            
            
        
        
        
        
    
    
            
    


    

