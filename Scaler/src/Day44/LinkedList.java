package Day44;

public class LinkedList {

	public static void main(String[] args) {
	}
	public static PalinLinkedList head = null;
	public static int n = 0;

	public static void insert_node(int position, int value){
	    if(position > n+1) return;

	    if(position == 1) { 
	    	head = new PalinLinkedList(value);
	    }
	    else{
	    	PalinLinkedList temp = head;
	        for(int i=1; i<position-1; i++) temp = temp.next;
	        var new_node = new PalinLinkedList(value);
	        new_node.next = temp.next;
	        temp.next = new_node;
	    }
	    n++;
	}

	public static void delete_node(int position){
	    if(position > n) return;

	    if(position == 1) head = head.next;
	    else{
	    	PalinLinkedList temp = head;
	        for(int i=1; i<position-1; i++) temp = temp.next;
	        temp.next = temp.next.next;
	    }
	    n--;
	}

	public static void print_ll(){
	    if(n == 0) return;

	    PalinLinkedList temp = head;
	    while(temp.next != null){
	        System.out.print(temp.val + " ");
	        temp = temp.next;
	    }
	    System.out.print(temp.val);
	}

}
